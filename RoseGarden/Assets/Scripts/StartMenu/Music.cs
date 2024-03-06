using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource ClickSound;
    public GameObject CheckMark;
    bool isOn;

    void Start()
    {
        isOn = true;
        CheckMark.SetActive(true);
    }

    public void ButtonEvent()
    {
        if(isOn == true)
        {
            ClickSound.Play();
            CheckMark.SetActive(false);
            BGM.Pause();
            isOn = false;
        }
        else
        {
            ClickSound.Play();
            CheckMark.SetActive(true);
            BGM.Play();
            isOn = true;
        }
    }
}
