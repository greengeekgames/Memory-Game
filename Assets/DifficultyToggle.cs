using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyToggle : MonoBehaviour
{
    private Toggle[] toggles = null;

    // Start is called before the first frame update
    void Start()
    {
        toggles = gameObject.GetComponentsInChildren<Toggle>();
        int currentDifficulty = Settingmanager.Instance.difficulty;
        if (currentDifficulty == 0)
            SetToggle("toggleeasy");
        else if (currentDifficulty == 1)
            SetToggle("togglenormal");
        else
            SetToggle("togglehard");
    }

    void SetToggle(string tname)
    {
        foreach (Toggle toggle in toggles)
        {
            if (toggle.name == tname)
            
                toggle.isOn = true;
            
            else
                toggle.isOn = false;
        }
    }
    void Update()
    { }
    // Update is called once per frame
    public void Updatedifficulty()
    {
        foreach(Toggle toggle in toggles)
        {
            if (toggle.isOn)
            {
                if (toggle.name == "toggleeasy") 
                Settingmanager.Instance.difficulty = 0;
                else if (toggle.name== "togglenormal")
                    Settingmanager.Instance.difficulty = 1;
                else
                    Settingmanager.Instance.difficulty = 2;
            }
        }
    }
}
