using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Doublsb.Dialog;

public class StoryEvent7 : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 9)
        {
            player.transform.position = new Vector2(-16, -15);
            Talk();
        }
        if (quest.QuestNum >= 10)
        {
            Destroy(Event);
        }
    }

    void Talk()
    {
        var dialog11 = new List<DialogData>();
        dialog11.Add(new DialogData("/emote:Sad/��.. �ִ� �Ա���.", "KaiMom"));
        dialog11.Add(new DialogData("/emote:Angry/��� ū �Ҹ��� �鸮����.. ���� �� ��������?", "Gerda"));
        dialog11.Add(new DialogData("/emote:Sad/���ܸ��� ���� ���� ������ �𸣰ڱ���...", "KaiMom"));
        dialog11.Add(new DialogData("/emote:Sad/���� ���ĺ��� ī�̰� �Ű��������� ���� �� ����. \n Ȥ�� ���� ���� ���� �־���..?", "KaiMom"));
        var dialogData5 = new DialogData("/emote:Sad/�׷�����...", "Gerda");
        dialogData5.Callback = () => LastLog();

        dialog11.Add(dialogData5);
        DialogManager.Show(dialog11);
    }

    void LastLog()
    {
        FadeIn.SetActive(true);
        message.SetActive(true);
        Invoke("invoke", 4.2f);
    }

    void invoke()
    {
        FadeIn.SetActive(false);
        FadeOut.SetActive(true);
        Invoke("Talk2", 1.2f);
    }

    void Talk2()
    {
        FadeOut.SetActive(false);
        Destroy(message);
        var dialog12 = new List<DialogData>();
        dialog12.Add(new DialogData("/emote:Sad/�׷� ���� �־�����... /click/\n���� ������ ������ ������ ��Ⱑ ���� ��� ������...", "KaiMom"));
        dialog12.Add(new DialogData("/emote:Sad/���� �����ٰ� ���� �� ��������� ���̴� �� �������.", "Gerda"));
        dialog12.Add(new DialogData("/emote:Sad/�켱... �ִپ�. ������� ã�ƿԴµ� �̾�������... ", "KaiMom"));
        dialog12.Add(new DialogData("/emote:NonExpression/ī�̰� ����� ����ġ�� ���� �Ⱦ��ϴ� �� ������", "KaiMom"));
        dialog12.Add(new DialogData("/emote:NonExpression/������� ���ƿ� �������� �ִ� �ʸ� ���ؼ��� \n���� ����ġ�� �ʴ°� ���� �� ������.", "KaiMom"));
        dialog12.Add(new DialogData("/emote:Sad/��.. ���� �������� �˰ھ��.", "Gerda"));
        dialog12.Add(new DialogData("/emote:Sad/��� �װ� ����� ū �Ҹ��� �� �̰� \nī�̿� ����غ��ڴٰ� �ߴٰ� �Ƿ� ��ó�� �ް� �԰ŵ�...", "KaiMom"));
        dialog12.Add(new DialogData("/emote:Sad/��.. �����߾��. ������ ���ư����Կ�.", "Gerda"));
        dialog12.Add(new DialogData("/emote:Sad/���� �̾��ϱ���...", "KaiMom"));
        dialog12.Add(new DialogData("/emote:Smile/�ƴϿ���! ī�̰� ���������� ���߿� �� �ðԿ�!", "Gerda"));
        dialog12.Add(new DialogData("������ ����.", "KaiMom"));
        dialog12.Add(new DialogData("/wait:0.7//emote:Sad/ī��... ��ü �� �׷��°Ŵ�...", "KaiMom"));
        DialogManager.Show(dialog12);
        quest.QuestNum++; //10
    }
}
