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

    // Start is called before the first frame update
    void Start()
    {
        textscore.text = "start";
        currentduration = startduration;
    }

    public void StartGame()
    {
        Debug.Log("start game!");
        textscore.text = "0";
        sequence.Clear();
        NextSequence();
    }

    void NextSequence()
    {
        textscore.text = sequence.Count.ToString();
        sequence.Add(Random.Range(0, buttons.Length-1));
        StartCoroutine(PlaySequence());
        Debug.Log("NextSequence End");
    }

    IEnumerator PlaySequence()
    {
        currentsequencestep = 0;
        ResetButtons();
        DisableButtons(true);

        while(currentsequencestep<sequence.Count)
        {
            int buttonindex = sequence[currentsequencestep];
            Debug.Log("Press button: " + buttonindex);
            PressButton(buttonindex);
            currentsequencestep++;
            yield return new WaitForSeconds(currentduration);
            ResetButtons();
            yield return new WaitForSeconds(currentduration);
        }
    }

    void PressButton(int bindex)
    {
        Button button = buttons[bindex];
        ColorBlock colorblock = button.colors;
        colorblock.disabledColor = colorblock.pressedColor;
        button.colors = colorblock;
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
