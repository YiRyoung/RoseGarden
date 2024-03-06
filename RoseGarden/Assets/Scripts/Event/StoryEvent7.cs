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
        dialog11.Add(new DialogData("/emote:Sad/아.. 겔다 왔구나.", "KaiMom"));
        dialog11.Add(new DialogData("/emote:Angry/방금 큰 소리가 들리던데.. 무슨 일 있으세요?", "Gerda"));
        dialog11.Add(new DialogData("/emote:Sad/아줌마도 도통 무슨 일인지 모르겠구나...", "KaiMom"));
        dialog11.Add(new DialogData("/emote:Sad/어제 오후부터 카이가 신경질적으로 변한 것 같아. \n 혹시 어제 무슨 일이 있었니..?", "KaiMom"));
        var dialogData5 = new DialogData("/emote:Sad/그러고보니...", "Gerda");
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
        dialog12.Add(new DialogData("/emote:Sad/그런 일이 있었구나... /click/\n집에 들어오고 나서는 아프단 얘기가 전혀 없어서 몰랐어...", "KaiMom"));
        dialog12.Add(new DialogData("/emote:Sad/저도 아프다고 했을 때 살펴봤지만 보이는 건 없었어요.", "Gerda"));
        dialog12.Add(new DialogData("/emote:Sad/우선... 겔다야. 여기까지 찾아왔는데 미안하지만... ", "KaiMom"));
        dialog12.Add(new DialogData("/emote:NonExpression/카이가 사람과 마주치는 것을 싫어하는 것 같으니", "KaiMom"));
        dialog12.Add(new DialogData("/emote:NonExpression/원래대로 돌아올 때까지는 겔다 너를 위해서라도 \n둘이 마주치지 않는게 좋을 것 같구나.", "KaiMom"));
        dialog12.Add(new DialogData("/emote:Sad/네.. 무슨 말씀인지 알겠어요.", "Gerda"));
        dialog12.Add(new DialogData("/emote:Sad/사실 네가 들었던 큰 소리도 그 이가 \n카이와 얘기해보겠다고 했다가 되려 상처만 받고 왔거든...", "KaiMom"));
        dialog12.Add(new DialogData("/emote:Sad/아.. 이해했어요. 집으로 돌아가볼게요.", "Gerda"));
        dialog12.Add(new DialogData("/emote:Sad/정말 미안하구나...", "KaiMom"));
        dialog12.Add(new DialogData("/emote:Smile/아니에요! 카이가 괜찮아지면 나중에 또 올게요!", "Gerda"));
        dialog12.Add(new DialogData("조심히 가렴.", "KaiMom"));
        dialog12.Add(new DialogData("/wait:0.7//emote:Sad/카이... 대체 왜 그러는거니...", "KaiMom"));
        DialogManager.Show(dialog12);
        quest.QuestNum++; //10
    }
}
