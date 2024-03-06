using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StoryEvent14 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Player player;
    public SnowPrince snowprince;
    public Quest quest;
    public GameObject Event;
    public GameObject Fadein;
    public GameObject FadeOut;
    public GameObject Effect;
    public GameObject prince;
    public GameObject timeline;

    void Start()
    {
        timeline.SetActive(false);
        Fadein.SetActive(false);
        FadeOut.SetActive(false);
        Effect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 17)
        {
            Fadein.SetActive(true);
            Invoke("Fade", 1.2f);
        }
        if (quest.QuestNum >= 18)
        {
            Destroy(Event);
        }
    }
    
    void Fade()
    {
        player.transform.position = new Vector2(5.3f, 33.4f);
        snowprince.transform.position = new Vector2(5.3f, 34.4f);
        Fadein.SetActive(false);
        FadeOut.SetActive(true);
        Invoke("Talk", 1.2f);
    }
    void Talk()
    {
        FadeOut.SetActive(false);
        var dialog22 = new List<DialogData>();
        dialog22.Add(new DialogData("��ó�� ī�̰� �ִ� �� �ϴ� ���뿡�� ������� �� �� ����.", "SnowPrince"));
        dialog22.Add(new DialogData("������� ���� ������, �ִ�.", "SnowPrince"));
        dialog22.Add(new DialogData("�̴�� ���÷�����? ���� ������ ���﷡��!", "Gerda"));
        dialog22.Add(new DialogData("������� ���� �����ϱ� ��������� �� �̻��� �� ��.", "SnowPrince"));
        dialog22.Add(new DialogData("�� ���� �����ؼ� ������ ����� ������� �־����ٵ�.", "SnowPrince"));
        dialog22.Add(new DialogData("��� ���� �Ŵ޷����� ���󰥰ſ���!", "Gerda"));
        dialog22.Add(new DialogData("/emote:Hum/������, ���� ������� �������� �� �Ϸ����� ���� ��� ����?", "Gerda"));
        dialog22.Add(new DialogData("/emote:Angry//speed:down/.../speed:init/", "SnowPrince"));
        dialog22.Add(new DialogData("/emote:Angry/�絹�� ���̳�. ī�� ��������.", "SnowPrince"));
        var dialogData = new DialogData("/emote:Magic/�׷� �̷��� ����. �װ� ������ ������ �� �� �ֵ��� ���ٰ�.", "SnowPrince");
        dialogData.Callback = () => effect();
        dialog22.Add(dialogData);
        DialogManager.Show(dialog22);
    }
    void effect()
    {
        Effect.SetActive(true);
        Destroy(Effect, 5f);
        Invoke("Talk1", 1.5f);
    }

    void Talk1()
    {
        timeline.SetActive(true);
        var dialog23 = new List<DialogData>();
        dialog23.Add(new DialogData("�� �պ��ʹ� ���Ͱ� ����ϴ� �����̾�.", "SnowPrince"));
        dialog23.Add(new DialogData("���� �װ� �������� 3���� ���� ���� �� �ִٸ�, �������ִ� �ɷ�.", "SnowPrince"));
        dialog23.Add(new DialogData("/emote:Hum/�� ������ �� ���ϱ� ���⿡��?", "Gerda"));
        dialog23.Add(new DialogData("/emote:Smile/�� ���κ���.", "SnowPrince"));
        var dialogData1 = new DialogData("���ƿ�! �ݹ� ��� ���ƿ���.", "Gerda");
        dialogData1.Callback = () => cam();
        dialog23.Add(dialogData1);
        DialogManager.Show(dialog23);
    }

    void cam()
    {
        timeline.SetActive(false);
        quest.QuestNum++;
    }
}
