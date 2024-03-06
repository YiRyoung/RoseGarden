using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StoryEvent8 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Player player;
    public Quest quest;
    public GameObject Event;
    public float speed;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 10)
        {
            player.anim.SetBool(player.isMove, true);
            Vector3 a = new Vector3(-18, -12, 0);
            player.transform.position = Vector3.Lerp(a, player.transform.position, speed * Time.deltaTime);
            quest.StroyEvent8();
        }
        else
        {
            player.anim.SetBool(player.isMove, false);
        }

        if(quest.QuestNum >= 11)
        {
            Destroy(Event);
        }
    }
}
