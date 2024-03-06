using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    public Button KeyDirection;
    public Button StatusWindow;
    public Button CloseShop;
    public AudioSource sound;

    void Update()
    {
        KeyDirection.onClick.AddListener(Sound);
        StatusWindow.onClick.AddListener(Sound);
        CloseShop.onClick.AddListener(Sound);
    }

    void Sound()
    {
        sound.Play();
    }
}
