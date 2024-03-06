using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFieldSound : MonoBehaviour
{
    public GameObject Player;
    public AudioSource WField;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(Player.GetComponent<Player>(). state != BattleState.WAIT)
        {
            WField.Stop();
        }
        else
        {
            if (!WField.isPlaying)
            {
                WField.Play();
            }
        }
    }
}
