using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject Image;
    public AudioSource StartMusic;
    public AudioSource BackMusic;

    public void GameStart()
    {
        StartMusic = GetComponent<AudioSource>();

        StartCoroutine(FadeOutStart());
        StartMusic.Play();
        StartCoroutine(Delay());
    }

    IEnumerator FadeOutStart()
    {
        Image.SetActive(true);
        for (float f = 0f; f < 1; f += 0.01f)
        {
            Color c = Image.GetComponent<Image>().color;
            c.a = f;
            Image.GetComponent<Image>().color = c;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        Image.SetActive(false);
    }

    IEnumerator Delay()
    {
        BackMusic.Stop();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}