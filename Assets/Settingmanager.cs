using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settingmanager : MonoBehaviour
{
    public static Settingmanager Instance { get; private set; }
    private const string VolumeKey = "Volume";
    private const string difficultykey = "Difficulty";

    void Awake()
    {
        Instance = this;
    }

    public float volume
    {
        get
        {
            if (PlayerPrefs.HasKey("Volume")) return 1;
            return PlayerPrefs.GetFloat(VolumeKey);
        }
        set
        {
            PlayerPrefs.SetFloat(VolumeKey, value);
        }

    }
    public int difficulty
    {
        get
        {
            if (PlayerPrefs.HasKey(difficultykey)) return 1;
            return PlayerPrefs.GetInt(difficultykey);
        }
        set
        {
            PlayerPrefs.SetInt(difficultykey, value);
        }
    }
}
