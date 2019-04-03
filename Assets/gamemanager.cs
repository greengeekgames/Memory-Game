using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    [SerializeField] public Button [] buttons;
    public float startduration = 0.3f;
    public float currentduration;
    public List<int> sequence;
    public Text textscore;
    public Text texthighscore;
    private int currentsequencestep;
    private const string Highscorekey = "Highscore";
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        textscore.text = "start";
      //  currentduration = startduration;
    }

    public int highscore
    {
        get{
            return PlayerPrefs.GetInt(Highscorekey);
        }
        set
        {
            PlayerPrefs.SetInt(Highscorekey, value);
            displayhighscore();
        }

    }

    void displayhighscore()
    {
        texthighscore.text = "High Score: " + highscore.ToString();
    }

    public void StartGame()
    {
        Debug.Log("start game!");
        textscore.text = "0";
        sequence.Clear();
        currentduration = startduration-(Settingmanager.Instance.difficulty*startduration/5.0f);
        NextSequence();
    }

    void NextSequence()
    {
       currentduration = currentduration * 0.99f;
        textscore.text = sequence.Count.ToString();
        sequence.Add(Random.Range(0, buttons.Length-1));
        StartCoroutine(PlaySequence());
        Debug.Log("NextSequence End");
    }

    IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(1f);
        currentsequencestep = 0;
        ResetButtons();
        DisableButtons(true);

        while (currentsequencestep < sequence.Count)
        {
            int buttonindex = sequence[currentsequencestep];
            Debug.Log("Press button: " + buttonindex);
            PressButton(buttonindex);
            currentsequencestep++;
            yield return new WaitForSeconds(currentduration);
            ResetButtons();
            yield return new WaitForSeconds(currentduration);
        }
        currentsequencestep = 0;
        DisableButtons(false);
    }

    public void PressedByUser(Button buttonpressed)
    {
        if (currentsequencestep >= sequence.Count) return;
        if(buttonpressed!=buttons[sequence[currentsequencestep]])
        {
            Debug.Log("Failed");
            audioData = buttonpressed.GetComponent<AudioSource>();
            audioData.Play(0);
            Start();
        }
        else
        {
            currentsequencestep++;
            if(currentsequencestep>=sequence.Count)
            {
                if (currentsequencestep > highscore) highscore = sequence.Count;
                NextSequence();
            }
        }
    }

    void PressButton(int bindex)
    {
        Button button = buttons[bindex];
        ColorBlock colorblock = button.colors;
        colorblock.disabledColor = colorblock.pressedColor;
        button.colors = colorblock;
        audioData = button.GetComponent<AudioSource>();
        audioData.Play();
    }

    void ResetButtons()
    {
        for(int i=0;i<buttons.Length;i++)
        {
            Button button = buttons[i];
            ColorBlock colorblock = button.colors;
            colorblock.disabledColor = colorblock.normalColor;
            button.colors = colorblock;
        }
    }

    void DisableButtons(bool Bdisable)
    {
        for (int i=0; i < buttons.Length;i++)
        {
            buttons[i].interactable = !Bdisable;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            NextSequence();
        }
    }


}
