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
            dialog8.Add(new DialogData("������ �����ϽŴ�ξ�.", "Gerda"));
            dialog8.Add(new DialogData("ī�̰� ���� �� ���Ƽ� ���ѷ��� ������ ���� ���� �־�.", "Gerda"));
            var dialogData4 = new DialogData("�켱 ǫ �ڰ� ���� ī�̸� ����������.", "Gerda");
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
        dialog9.Add(new DialogData("���� �����̾�!", "Gerda"));
        dialog9.Add(new DialogData("�䵵 ����� �Ծ����� ī�̳� ������ ����!", "Gerda"));
        dialog9.Add(new DialogData("ī�̳� ���� �ٷ� �����ʿ� �־�.", "Gerda"));
        dialog9.Add(new DialogData("/emote:Sad/�ε�... �����ƾ����ٵ�.", "Gerda"));

        DialogManager.Show(dialog9);
        quest.QuestNum++;
    }
}
