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
        dialog18.Add(new DialogData("역시 숲 근처에는 아직 안 밟힌 눈이 많이 있네!", "Gerda"));
        var dialogData = new DialogData("어? 저곳에 무언가가 반짝이는 것 같아.", "Gerda");
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
        dialog19.Add(new DialogData("입구와 그리 멀어보이지도 않는데... 한번 가볼까?", "Gerda"));
        dialog19.Add(new DialogData("여차하면 바로 뛰쳐나오자.", "Gerda"));
        DialogManager.Show(dialog19);
        quest.QuestNum++; //14
    }
}
