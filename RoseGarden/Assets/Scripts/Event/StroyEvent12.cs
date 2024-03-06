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
        dialog21.Add(new DialogData("저희 마을은 저희 집을 기준으로 밑 부분과 왼쪽 부분으로 나눠져있어요.", "Gerda"));
        dialog21.Add(new DialogData("/emote:Magic/확실히, 두 군데에서 소리가 들려.", "SnowPrince"));
        dialog21.Add(new DialogData("그럼 어딜 먼저 갈까요?", "Gerda"));
        var dialogData = new DialogData("안내자가 원하는 곳부터 가도록 할까.", "SnowPrince");
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
