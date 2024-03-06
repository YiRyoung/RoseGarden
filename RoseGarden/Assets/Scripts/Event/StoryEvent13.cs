using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StoryEvent13 : MonoBehaviour
{
    public Quest quest;
    public GameObject Event;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum >= 17)
        {
            Destroy(Event);
        }
    }
}
