using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Doublsb.Dialog;

public class StroyEvent12 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Quest quest;
    public GameObject Event;
    public GameObject Fadein;
    public GameObject Fadeout;
    public GameObject timeline;
    public GameObject Villiagers;

    void Start()
    {
        timeline.SetActive(false);
        Fadein.SetActive(false);
        Fadeout.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 15)
        {
            Villiagers.SetActive(true);
            Talk();
        }
        if (quest.QuestNum >= 16)
        {
            Destroy(Event);
        }
    }

    void Talk()
    {
        timeline.SetActive(true);
        var dialog21 = new List<DialogData>();
        dialog21.Add(new DialogData("���� ������ ���� ���� �������� �� �κа� ���� �κ����� �������־��.", "Gerda"));
        dialog21.Add(new DialogData("/emote:Magic/Ȯ����, �� �������� �Ҹ��� ���.", "SnowPrince"));
        dialog21.Add(new DialogData("�׷� ��� ���� �����?", "Gerda"));
        var dialogData = new DialogData("�ȳ��ڰ� ���ϴ� ������ ������ �ұ�.", "SnowPrince");
        dialogData.Callback = () => CameraOff();
        dialog21.Add(dialogData);
        DialogManager.Show(dialog21);
    }

    void CameraOff()
    {
        timeline.SetActive(false);
        quest.QuestNum++; //16
    }
}
