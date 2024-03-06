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
        dialog14.Add(new DialogData("/emote:Angry/�� ���� ���������� ī�� �θ�԰��� �� ������ �� ���� �귶��.", "Gerda"));
        dialog14.Add(new DialogData("/emote:Angry/�� �� ����, �� ���� ī�̰� ������� ���ƿ��⸦ ��ٷȴ�.", "Gerda"));
        dialog14.Add(new DialogData("/emote:Angry/������ ī�̴� ���� �������� ���� �� ���������� ���ߴ�.", "Gerda"));
        dialog14.Add(new DialogData("/emote:Angry/ī�̳� �θ���� ī�̰� ������ �ϵ��� �����ϴ��� �ٺ�������.", "Gerda"));
        dialog14.Add(new DialogData("/emote:Angry/�׷��� ī�̳� �θ�Բ��� �����ϼ̴� �Ѱ����� �Ͼ�� �ʾҴ�.", "Gerda"));
        var dialogData6 = new DialogData("/emote:Sad/ī�̴� ���� �������⺸�� ȥ�� ������ ��� ���� �� ���������ϱ�...", "Gerda");
        dialogData6.Callback = () => Invoke("Talk1", 2f);
        dialog14.Add(dialogData6);
        DialogManager.Show(dialog14);
    }

    void Talk1()
    {
        var dialog15 = new List<DialogData>();
        dialog15.Add(new DialogData("/wait:0.5//emote:Angry/�ð��� ������ �귯 �ĸ��ߴ� ���� �ݼ� �������� �ܿ��� ã�ƿԴ�.", "Gerda"));
        dialog15.Add(new DialogData("/emote:Sad/�׵��� �������� ī�̿� ���� ������ ���̴� ����� �� �� �� �þ���.", "Gerda"));
        dialog15.Add(new DialogData("/emote:Angry/������ ��ε� �������� �ٽ� ���ƿ����� �ϰ� �־���.", "Gerda"));
        var dialogData7 = new DialogData("�������� �� �Ǹ����� ã�� �� ���̶��, ��� �׷��� �Ͼ���.", "Gerda");
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
        dialog16.Add(new DialogData("/emote:Sad/���õ� ī�̴� ȥ�� ��Ÿ� Ÿ�� ��������...", "Gerda"));
        dialog16.Add(new DialogData("������! ���� ȥ�ڼ� �� �� �� �ִ°�!", "Gerda"));
        dialog16.Add(new DialogData("���� ���� ���� ������� �� �ִ��� Ȯ���غ���?", "Gerda"));
        dialog16.Add(new DialogData("������ �ѷ����� ���Ϳ� �����ž�.", "Gerda"));
        DialogManager.Show(dialog16);
        quest.QuestNum++; //12
    }


}
