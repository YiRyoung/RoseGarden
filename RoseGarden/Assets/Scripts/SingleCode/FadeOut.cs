using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public GameObject Out;

    //ÆäÀÌµå ¾Æ¿ô
    IEnumerator FadeOutStart()
    {
        Out.SetActive(true);
        for (float f = 1f; f > 0; f -= 0.005f)
        {
            Color c = Out.GetComponent<Image>().color;
            c.a = f;
            Out.GetComponent<Image>().color = c;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        Out.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(FadeOutStart());
    }
}
