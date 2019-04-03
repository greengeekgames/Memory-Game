using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menumanager : MonoBehaviour
{
    public Animator settingsAnimator;
    public bool settingsOpen = false;

    public void Togglesettings()
    {
        settingsOpen = !settingsOpen;
        if (settingsOpen)
            settingsAnimator.Play("Opensettings");
        else
            settingsAnimator.Play("Closesettings");
    }
}
