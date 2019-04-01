using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public Button[] buttons;
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
    }
    // Update is called once per frame
    void Update()
    {


    }
}
