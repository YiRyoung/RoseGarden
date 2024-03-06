using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Doublsb.Dialog;

public class StoryEvent2 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Player player;
    public Quest quest;
    public GameObject Event;
    public GameObject FadeIn;
    public GameObject FadeOut;
    public GameObject message;

    private void Start()
    {
        FadeIn.SetActive(false);
        FadeOut.SetActive(false);
        message.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 2)
        {
            Event.SetActive(true);
            var dialog2 = new List<DialogData>();
            dialog2.Add(new DialogData("�̾���! ���� ���� �ʾ���?", "Gerda"));
            dialog2.Add(new DialogData("������, ���� ��� �Ծ�.", "Kai"));
            dialog2.Add(new DialogData("� �ɾ�, ��Ӵϲ��� ���ִ� �������̸� ���ּ̾�.", "Kai"));
            dialog2.Add(new DialogData("/emote:Smile/���! ������ �� �԰ڴٰ� ���ص����.", "Gerda"));
            var dialogData1 = new DialogData("/emote:Smile/��������.", "Kai");
            dialogData1.Callback = () => LastLog2();
            dialog2.Add(dialogData1);
            DialogManager.Show(dialog2);
            quest.QuestNum++; //3
        }

        if (quest.QuestNum >= 4)
        {
            Destroy(Event);
        }
    }

    void LastLog2()
    {
        player.transform.position = new Vector2(13.6f, -9.8f);
        player.anim.SetBool(player.Read, true);
        FadeIn.SetActive(true);
        message.SetActive(true);
        Invoke("invoke1", 3f);
    }

    void invoke1()
    {
        FadeIn.SetActive(false);
        FadeOut.SetActive(true);
        Invoke("invoke2", 0.7f);
    }

    void invoke2()
    {
        FadeOut.SetActive(false);
        Destroy(message);
        Talk2();
    }

    void Talk2()
    {
        var dialog3 = new List<DialogData>();
        dialog3.Add(new DialogData("/emote:Sad/�ƾ�! ���� ������ ����!", "Kai"));
        dialog3.Add(new DialogData("ī��, ������?", "Gerda"));
        dialog3.Add(new DialogData("/emote:Sad/�������� ���� �� ���� �񷶾�! ���� �ʵ�!", "Kai"));
        dialog3.Add(new DialogData("/emote:Angry/��.. ���⼭�� �� �� ���̴µ�...", "Gerda"));
        dialog3.Add(new DialogData("/emote:Angry/���� �� ������ ���� Ȯ���غ���.", "Gerda")); 
        player.anim.SetBool(player.Read, false);
        DialogManager.Show(dialog3);
        quest.QuestNum++; //4
    }

}
