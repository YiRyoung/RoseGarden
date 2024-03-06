using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purchase : MonoBehaviour
{
    public Player player;
    public GameObject NotEnough;
    public AudioSource purchase;
    public AudioSource notEnough;

    void Start()
    {
        NotEnough.SetActive(false);
    }

    public void Store_HPPotion()
    {
        if (player.status.Coin >= 15)
        {
            purchase.Play();
            player.status.Coin -= 15;
            player.potion.HPPotion++;
        }
        else
        {
            StartCoroutine(Notenough());
        }
    }

    public void Store_MPPotion()
    {
        if (player.status.Coin >= 15)
        {
            purchase.Play();
            player.status.Coin -= 15;
            player.potion.MPPotion++;
        }
        else
        {
            StartCoroutine(Notenough());
        }
    }

    IEnumerator Notenough()
    {
        notEnough.Play();
        NotEnough.SetActive(true);
        yield return new WaitForSeconds(1f);
        NotEnough.SetActive(false);
        yield return null;
    }
}
