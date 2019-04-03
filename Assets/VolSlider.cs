using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolSlider : MonoBehaviour
{
   [SerializeField] public Slider slider;
    [SerializeField] public Sprite[] sprites;
    [SerializeField] public Image image;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = Settingmanager.Instance.volume;
        UpdateVolume();
    }

    public void UpdateVolume()
    {
        Settingmanager.Instance.volume = slider.value;
        if (slider.value == 0)
            image.overrideSprite = sprites[0];
        else if (slider.value < 0.5)
            image.overrideSprite = sprites[1];
        else
            image.overrideSprite = sprites[2];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
