using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Doublsb.Dialog;

public class StoryEvent5 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Player player;
    public Quest quest;
    public GameObject Event;
    public GameObject FadeIn;
    public GameObject FadeOut;
    public GameObject message;
    GameObject kai;

    void Start()
    {
        message.SetActive(false);
        FadeIn.SetActive(false);
        FadeOut.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && quest.QuestNum == 7)
        {
            Talk();
        }
        if(quest.QuestNum >= 8)
        {
            Destroy(Event);
        }

        void Talk()
        {
            var dialog8 = new List<DialogData>();
            dialog8.Add(new DialogData("엄마가 말씀하신대로야.", "Gerda"));
            dialog8.Add(new DialogData("카이가 몸이 안 좋아서 서둘러서 집으로 갔을 수도 있어.", "Gerda"));
            var dialogData4 = new DialogData("우선 푹 자고 내일 카이를 만나러가자.", "Gerda");
            dialogData4.Callback = () => LastLog4();

            dialog8.Add(dialogData4);
            DialogManager.Show(dialog8);
        }
    }

    void LastLog4()
    {
        FadeIn.SetActive(true);
        message.SetActive(true);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        FadeIn.SetActive(false);
        FadeOut.SetActive(true);
        player.transform.position = new Vector2(2.7f, 2.5f);
        Destroy(message);
        Invoke("Talk1", 1.5f);
    }

    void Talk1()
    {
        var dialog9 = new List<DialogData>();
        dialog9.Add(new DialogData("좋은 점심이야!", "Gerda"));
        dialog9.Add(new DialogData("밥도 든든히 먹었으니 카이네 집으로 가자!", "Gerda"));
        dialog9.Add(new DialogData("카이네 집은 바로 오른쪽에 있어.", "Gerda"));
        dialog9.Add(new DialogData("/emote:Sad/부디... 괜찮아야할텐데.", "Gerda"));

        DialogManager.Show(dialog9);
        quest.QuestNum++;
    }
}
