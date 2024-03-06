using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using TMPro;

public class StoryEvent4 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Player player;
    public Quest quest;
    public GameObject Event;
    public GameObject FadeIn;
    public GameObject FadeOut;
    public GameObject message;

    void Start()
    {
        message.SetActive(false);
        FadeIn.SetActive(false);
        FadeOut.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 5)
        {
            Talk();
        }
        if(quest.QuestNum >= 7)
        {
            Destroy(Event);
        }
    }

    void Talk()
    {
        var dialog6 = new List<DialogData>();
        dialog6.Add(new DialogData("/emote:Sad/�ٳ�Խ��ϴ�..", "Gerda"));
        dialog6.Add(new DialogData("/emote:Serious/ ����� �� ���ƺ��̴µ�.. ���� �� �־���?", "Mommy"));
        var dialogData3 = new DialogData("�װ�...", "Gerda");
        dialogData3.Callback = () => LastLog3();

        dialog6.Add(dialogData3);
        DialogManager.Show(dialog6);
        quest.QuestNum++; //6
    }

    void LastLog3()
    {
        FadeIn.SetActive(true);
        message.SetActive(true);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        player.transform.position = new Vector2(1.5f, -17.8f);
        yield return new WaitForSeconds(3f);
        FadeIn.SetActive(false);
        FadeOut.SetActive(true);
        Destroy(message);
        Invoke("Talk1", 1f);
    }

   void Talk1()
    {
        var dialog7 = new List<DialogData>();
        dialog7.Add(new DialogData("/emote:NotGood/����.. �׷� ���� �־�����.", "Mommy"));
        dialog7.Add(new DialogData("�켱 ������ ǫ ���� ���� ã�ư����°� ���?", "Mommy"));
        dialog7.Add(new DialogData("�ʹ� ���ļ� ��� �׷��� ���� ���ݴ�.", "Mommy"));
        dialog7.Add(new DialogData("�׷��߰ھ��. ����ּż� �����ؿ�.", "Gerda"));
        dialog7.Add(new DialogData("����� ���������� ���ڱ���.", "Mommy"));
        dialog7.Add(new DialogData("/emote:Smile/���� ���п� ���� ���������.", "Gerda"));
        dialog7.Add(new DialogData("���� �ö󰡺��Կ�.", "Gerda"));

        DialogManager.Show(dialog7);
        quest.QuestNum++; //7
    }
}
