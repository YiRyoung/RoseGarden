using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattle : MonoBehaviour
{
    public Player player;
    public AudioSource Battle;

    void Update()
    {
        if(player.state != BattleState.WAIT)
        {
            if(!Battle.isPlaying)
            {
                Battle.Play();
            }
        }
        else
        {
            Battle.Stop();
        }
    }
}
