using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Skipbutton { Skip1, Skip2 }

public class SkipButton : MonoBehaviour
{
    public Skipbutton skip;
    public GameObject Skip;
    public AudioSource ButtonMusic;
    public AudioSource BackMusic;

    public void SkipScene()
    {
        switch(skip)
        {
            case Skipbutton.Skip1:
                ButtonMusic = GetComponent<AudioSource>();
                StartCoroutine(FadeOutStart());
                ButtonMusic.Play();
                StartCoroutine(Delay1());
                break;
            case Skipbutton.Skip2:
                ButtonMusic = GetComponent<AudioSource>();
                StartCoroutine(FadeOutStart());
                ButtonMusic.Play();
                StartCoroutine(Delay2());
                break;
        }
       
    }

    IEnumerator FadeOutStart()
    {
        Skip.SetActive(true);
        for (float f = 0f; f < 1; f += 0.01f)
        {
            Color c = Skip.GetComponent<Image>().color;
            c.a = f;
            Skip.GetComponent<Image>().color = c;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        Skip.SetActive(false);
    }

    IEnumerator Delay1()
    {
        BackMusic.Stop();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(2);
    }

    IEnumerator Delay2()
    {
        BackMusic.Stop();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(6);
    }
}
