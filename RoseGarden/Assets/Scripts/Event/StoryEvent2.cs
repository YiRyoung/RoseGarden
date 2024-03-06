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
            dialog2.Add(new DialogData("미안해! 내가 많이 늦었지?", "Gerda"));
            dialog2.Add(new DialogData("괜찮아, 나도 방금 왔어.", "Kai"));
            dialog2.Add(new DialogData("어서 앉아, 어머니께서 맛있는 애플파이를 해주셨어.", "Kai"));
            dialog2.Add(new DialogData("/emote:Smile/우와! 감사히 잘 먹겠다고 전해드려줘.", "Gerda"));
            var dialogData1 = new DialogData("/emote:Smile/물론이지.", "Kai");
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
        dialog3.Add(new DialogData("/emote:Sad/아야! 눈에 뭔가가 들어갔어!", "Kai"));
        dialog3.Add(new DialogData("카이, 괜찮아?", "Gerda"));
        dialog3.Add(new DialogData("/emote:Sad/얼음조각 같은 게 눈을 찔렀어! 가슴 쪽도!", "Kai"));
        dialog3.Add(new DialogData("/emote:Angry/음.. 여기서는 잘 안 보이는데...", "Gerda"));
        dialog3.Add(new DialogData("/emote:Angry/조금 더 가까이 가서 확인해보자.", "Gerda")); 
        player.anim.SetBool(player.Read, false);
        DialogManager.Show(dialog3);
        quest.QuestNum++; //4
    }

}
