using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionPanel : MonoBehaviour
{

    public AudioSource audio;
    public Image speaker;
    public Sprite[] speakerSprites;
    public Slider slider;



    void OnEnable()
    {
        slider.value = PlayerPrefs.GetFloat("Volume");
    }

    public void adjustVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);

        audio.volume = PlayerPrefs.GetFloat("Volume");


        if (value==0)
        {
            speaker.sprite = speakerSprites[0];
        }

        if(value<=.3333f && value !=0)
        {
            speaker.sprite = speakerSprites[1];
        }
        
        else if(value>.3333f && value <=.6666f)
        {
            speaker.sprite = speakerSprites[2];
        }

        else if(value > .6666f)
        {
            speaker.sprite = speakerSprites[3];
        }
    }
}
