using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StoryEvent6 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Player player;
    public Quest quest;
    public GameObject Event;
    public AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 8)
        {
            music.Play();
            StartCoroutine(stroyEvent6());
        }
        
        if(quest.QuestNum >= 9)
        {
            Destroy(Event);
        }
    }

    IEnumerator stroyEvent6()
    {
        yield return new WaitForSeconds(1f);
        quest.StoryEvent6();
    }
}
