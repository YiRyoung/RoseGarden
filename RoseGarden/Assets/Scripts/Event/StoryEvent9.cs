using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Doublsb.Dialog;

public class StoryEvent9 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Quest quest;
    public Player player;
    public GameObject FadeIn;
    public GameObject Chapter2;
    public GameObject Event;

    void Start()
    {
        FadeIn.SetActive(false);
        Chapter2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 10)
        {
           FadeIn.SetActive(true);
            Invoke("invoke", 1.2f);
        }
        if (quest.QuestNum >= 12)
        {
            Event.SetActive(false);
        }
    }

    void invoke()
    {
        player.transform.position = new Vector2(-0.5f, 0);
        quest.QuestNum++; //11
        SceneManager.LoadScene(5);
        StartCoroutine(Next());
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(2f);
        FadeIn.SetActive(false);
        Talk();
    }

    public void Talk()
    {
        var dialog14 = new List<DialogData>();
        dialog14.Add(new DialogData("/emote:Angry/그 날을 마지막으로 카이 부모님과도 못 만난지 몇 달이 흘렀다.", "Gerda"));
        dialog14.Add(new DialogData("/emote:Angry/그 날 이후, 난 매일 카이가 원래대로 돌아오기를 기다렸다.", "Gerda"));
        dialog14.Add(new DialogData("/emote:Angry/하지만 카이는 날이 지날수록 더욱 더 폭력적으로 변했다.", "Gerda"));
        dialog14.Add(new DialogData("/emote:Angry/카이네 부모님은 카이가 저지른 일들을 수습하느라 바빠보였다.", "Gerda"));
        dialog14.Add(new DialogData("/emote:Angry/그래도 카이네 부모님께서 걱정하셨던 한가지는 일어나지 않았다.", "Gerda"));
        var dialogData6 = new DialogData("/emote:Sad/카이는 나를 괴롭히기보다 혼자 나가서 노는 것을 더 좋아했으니까...", "Gerda");
        dialogData6.Callback = () => Invoke("Talk1", 2f);
        dialog14.Add(dialogData6);
        DialogManager.Show(dialog14);
    }

    void Talk1()
    {
        var dialog15 = new List<DialogData>();
        dialog15.Add(new DialogData("/wait:0.5//emote:Angry/시간은 빠르게 흘러 파릇했던 봄은 금세 지나가고 겨울이 찾아왔다.", "Gerda"));
        dialog15.Add(new DialogData("/emote:Sad/그동안 마을에는 카이와 같은 증상을 보이는 사람이 몇 명 더 늘었다.", "Gerda"));
        dialog15.Add(new DialogData("/emote:Angry/하지만 모두들 언젠가는 다시 돌아오리라 믿고 있었다.", "Gerda"));
        var dialogData7 = new DialogData("언젠가는 그 실마리를 찾게 될 것이라고, 모두 그렇게 믿었다.", "Gerda");
        dialogData7.Callback = () => loadScene();
        dialog15.Add(dialogData7);
        DialogManager.Show(dialog15);
    }

    void loadScene()
    {
        SceneManager.LoadScene(6);
        Chapter2.SetActive(true);
        Destroy(Chapter2, 4.5f);
        Invoke("Talk2", 5.2f);
    }

    void Talk2()
    {
        var dialog16 = new List<DialogData>();
        dialog16.Add(new DialogData("/emote:Sad/오늘도 카이는 혼자 썰매를 타러 나갔겠지...", "Gerda"));
        dialog16.Add(new DialogData("괜찮아! 나도 혼자서 잘 놀 수 있는걸!", "Gerda"));
        dialog16.Add(new DialogData("어제 내가 만든 눈사람이 잘 있는지 확인해볼까?", "Gerda"));
        dialog16.Add(new DialogData("나무로 둘러싸인 공터에 있을거야.", "Gerda"));
        DialogManager.Show(dialog16);
        quest.QuestNum++; //12
    }


}
