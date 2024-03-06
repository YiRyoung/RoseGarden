using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Doublsb.Dialog;

public class StroyEvent11 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Quest quest;
    public GameObject Event;
    public GameObject Effect;
    public GameObject Fadein;
    public GameObject Fadeout;
    public GameObject timeline;

    void Start()
    {
        Fadein.SetActive(false);
        Fadeout.SetActive(false);
        Effect.SetActive(false);
        timeline.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 13)
        {
            Talk();
            
        }
        if (quest.QuestNum >= 14)
        {
            Destroy(Event);
        }
        
    }

    void Talk()
    {
        var dialog18 = new List<DialogData>();
        dialog18.Add(new DialogData("���� �� ��ó���� ���� �� ���� ���� ���� �ֳ�!", "Gerda"));
        var dialogData = new DialogData("��? ������ ���𰡰� ��¦�̴� �� ����.", "Gerda");
        dialogData.Callback = () => Next();
        dialog18.Add(dialogData);
        DialogManager.Show(dialog18);
    }

    void Next()
    {
        timeline.SetActive(true);
        Effect.SetActive(true);
        Destroy(timeline, 4.2f);
        Invoke("invoke", 3f);
    }

    void invoke()
    {
        Fadein.SetActive(true);
        Invoke("invoke1", 1.2f);
    }

    void invoke1()
    {
        Fadein.SetActive(false);
        Fadeout.SetActive(true);
        Invoke("Talk2", 1.2f);
    }

    void Talk2()
    {
        Fadeout.SetActive(false);
        var dialog19 = new List<DialogData>();
        dialog19.Add(new DialogData("�Ա��� �׸� �־������ �ʴµ�... �ѹ� ������?", "Gerda"));
        dialog19.Add(new DialogData("�����ϸ� �ٷ� ���ĳ�����.", "Gerda"));
        DialogManager.Show(dialog19);
        quest.QuestNum++; //14
    }
}
