using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StoryEvent10 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Quest quest;
    public GameObject Event;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 12)
        {
            quest.StoryEvent10();
        }
        if (quest.QuestNum >= 13)
        {
            Destroy(Event);
        }
    }
}
