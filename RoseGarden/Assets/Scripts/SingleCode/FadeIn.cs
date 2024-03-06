using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public GameObject In;

    //페이드 인
    IEnumerator FadeInStart()
    {
        In.SetActive(true);
        for (float f = 0f; f < 1; f += 0.005f)
        {
            Color c = In.GetComponent<Image>().color;
            c.a = f;
            In.GetComponent<Image>().color = c;
            yield return null;
        }
    }

    public void FadeinStart()
    {
        StartCoroutine(FadeInStart());
    }
}
