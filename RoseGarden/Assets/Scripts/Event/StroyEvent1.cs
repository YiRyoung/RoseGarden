using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StroyEvent1 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Quest quest;
    public GameObject Event;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && quest.QuestNum == 1)
        {
            quest.StoryEvent1();
        }
        if (quest.QuestNum >= 3)
        {
            Destroy(Event);
        }

    }
}
