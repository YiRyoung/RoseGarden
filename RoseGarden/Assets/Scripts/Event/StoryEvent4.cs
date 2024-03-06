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
        dialog6.Add(new DialogData("/emote:Sad/다녀왔습니다..", "Gerda"));
        dialog6.Add(new DialogData("/emote:Serious/ 기분이 안 좋아보이는데.. 무슨 일 있었니?", "Mommy"));
        var dialogData3 = new DialogData("그게...", "Gerda");
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
        dialog7.Add(new DialogData("/emote:NotGood/저런.. 그런 일이 있었구나.", "Mommy"));
        dialog7.Add(new DialogData("우선 오늘은 푹 쉬고 내일 찾아가보는건 어떨까?", "Mommy"));
        dialog7.Add(new DialogData("너무 아파서 놀라서 그랬을 수도 있잖니.", "Mommy"));
        dialog7.Add(new DialogData("그래야겠어요. 들어주셔서 감사해요.", "Gerda"));
        dialog7.Add(new DialogData("기분이 나아졌으면 좋겠구나.", "Mommy"));
        dialog7.Add(new DialogData("/emote:Smile/엄마 덕분에 많이 나아졌어요.", "Gerda"));
        dialog7.Add(new DialogData("이제 올라가볼게요.", "Gerda"));

        DialogManager.Show(dialog7);
        quest.QuestNum++; //7
    }
}
