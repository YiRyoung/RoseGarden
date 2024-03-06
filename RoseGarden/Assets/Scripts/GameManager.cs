using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Doublsb.Dialog;
using TMPro;

public class GameManager : MonoBehaviour
{
    public DialogManager DialogManager;
    public Player player;
    public Quest quest;
    public GameObject scanObject;
    public GameObject Fadein;
    public GameObject Fadeout;
    public AudioSource Healing_Bed;

    [Header("Shop")]
    public GameObject whereShop;
    public GameObject ShopPannel;
    public TextMeshProUGUI Coin;
    public TextMeshProUGUI HpCount;
    public TextMeshProUGUI MpCount;

    void Start()
    {
        whereShop.SetActive(false);
        Fadein.SetActive(false);
        Fadeout.SetActive(false);
        ShopPannel.SetActive(false);
    }

    void Update()
    {
        Coin.text = player.status.Coin.ToString();
        HowPotion();
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectType objectType = scanObject.GetComponent<ObjectType>();
        Talk(objectType.Id);
    }

    void Talk(int Id)
    {

        switch (Id)
        {
            #region ObjectDialog
            case 100:
                var Object100 = new List<DialogData>();
                Object100.Add(new DialogData("ǫ���غ��̴� ħ���. ���� �� �� �� ����.", "Gerda"));
                var object100 = new DialogData("���� ������ �߱�?");
                object100.SelectList.Add("Correct", "����");
                object100.SelectList.Add("Wrong", "�Ⱦ�");
                object100.Callback = () => Check_Correct();
                Object100.Add(object100);
                DialogManager.Show(Object100);
                break;
            case 101:
                var Object101 = new List<DialogData>();
                Object101.Add(new DialogData("�ϱ����� �����ִ�.", "Gerda"));
                Object101.Add(new DialogData("���� �Ͼ ���� ����ұ�?", "Gerda"));
                DialogManager.Show(Object101);
                break;
            case 102:
                var Object102 = new List<DialogData>();
                Object102.Add(new DialogData("�پ��� å���� �����ִ�.", "Gerda"));
                Object102.Add(new DialogData("���� ���� �б⿣ ��������̴� �͵鵵 �� �ִ�.", "Gerda"));
                DialogManager.Show(Object102);
                break;
            case 103:
                var Object103 = new List<DialogData>();
                Object103.Add(new DialogData("�ʰ����� �������� �����Ǿ��ִ�.", "Gerda"));
                DialogManager.Show(Object103);
                break;
            case 104:
                var Object104 = new List<DialogData>();
                Object104.Add(new DialogData("�پ��� ������ �ʵ��� ����ϰ� �����Ǿ��ִ�.", "Gerda"));
                DialogManager.Show(Object104);
                break;
            case 105:
                var Object105 = new List<DialogData>();
                Object105.Add(new DialogData("���� ������ ���� Ŀ�ǰ� �ٱ�� �Բ� ���õǾ��ִ�.", "Gerda"));
                DialogManager.Show(Object105);
                break;
            case 106:
                var Object106 = new List<DialogData>();
                Object106.Add(new DialogData("����� �ȿ��� �ż��� ������ �����Ǿ��ִ�.", "Gerda"));
                DialogManager.Show(Object106);
                break;
            case 107:
                var Object107 = new List<DialogData>();
                Object107.Add(new DialogData("��ũ�뿡�� �������Ÿ� �ϳ� ���� �����ϴ�.", "Gerda"));
                Object107.Add(new DialogData("������ �������� ���� ���ֽô� �����̴�.", "Gerda"));
                DialogManager.Show(Object107);
                break;

            case 120:
                var Object120 = new List<DialogData>();
                Object120.Add(new DialogData("����� �޷��ִ� ����.", "Gerda"));
                Object120.Add(new DialogData("������ ���� �޷��־ �� �� ����...", "Gerda"));
                DialogManager.Show(Object120);
                break;
            case 121:
                var Object121 = new List<DialogData>();
                Object121.Add(new DialogData("������ �޷��ִ� ����.", "Gerda"));
                Object121.Add(new DialogData("������ �츮�� Ű�� �� �ƴϾ�.", "Gerda"));
                DialogManager.Show(Object121);
                break;
            case 130:
                var Object130 = new List<DialogData>();
                Object130.Add(new DialogData("�߻����� ����!", "Announce"));
                DialogManager.Show(Object130);
                break;
            case 131:
                var Object131 = new List<DialogData>();
                Object131.Add(new DialogData("���� ���� ����� �����.", "Gerda"));
                Object131.Add(new DialogData("�����鿩 ���縸ŭ �Ϳ���.", "Gerda"));
                DialogManager.Show(Object131);
                break;
            case 132:
                var Object132 = new List<DialogData>();
                Object132.Add(new DialogData("���� ���� ī�� �����.", "Gerda"));
                Object132.Add(new DialogData("/emote:Sad/���� ������ ƽƽ��� ���� �� ����ش�.", "Gerda"));
                Object132.Add(new DialogData("/emote:Sad/���� �̿�! ������ ī��!", "Gerda"));
                Object132.Add(new DialogData("�׷��� �߿��״ϱ� ���÷��� �ѷ����.", "Gerda"));
                DialogManager.Show(Object132);
                break;
            case 133:
                var Object133 = new List<DialogData>();
                Object133.Add(new DialogData("���� �Ǿ���� ����.", "Gerda"));
                Object133.Add(new DialogData("����ó�� ���� ���� ���̸� ��ŷ� �ٲ� ����� ����ϱ⵵ �Ѵ�.", "Gerda"));
                DialogManager.Show(Object133);
                break;
            #endregion

            #region QuestDialog
            case 500:
                quest.StroyEvent11();
                break;
            case 501:
                quest.Quest1();
                break;
            case 502:
                quest.Quest2();
                break;
            case 503:
                quest.Quest3();
                break;
            case 504:
                quest.Quest4();
                break;
            case 505:
                quest.Quest5();
                break;
            case 506:
                quest.Quest6();
                break;
            case 507:
                quest.Quest7();
                break;
            #endregion

            #region NPC_Dialog
            case 1000:
                    var NPC1 = new List<DialogData>();
                    NPC1.Add(new DialogData("���� �� �ִ�?", "Mommy"));
                    NPC1.Add(new DialogData("�׳� �ҷ��þ��.", "Gerda"));
                    NPC1.Add(new DialogData("�ʿ��� ���� �ִٸ� �������� �θ���.", "Mommy"));
                    DialogManager.Show(NPC1);
                break;
            case 1001:
                var NPC2 = new List<DialogData>();
                NPC2.Add(new DialogData("���, �ִ� �Ա���?", "KaiMom"));
                NPC2.Add(new DialogData("/emote:Smile/���� ��ٰ� ����.", "KaiMom"));
                DialogManager.Show(NPC2);
                break;
            case 1002:
                var NPC3 = new List<DialogData>();
                NPC3.Add(new DialogData("���. �ִ� �Դ�?", "KaiDad"));
                NPC3.Add(new DialogData("/emote:Umm/......", "KaiDad"));
                NPC3.Add(new DialogData("/emote:Umm/�̾�, �������� ���� �� �ٺ���...", "KaiDad"));
                DialogManager.Show(NPC3);
                break;
            case 1003:
                SnowPrince();
                break;
            case 1004:
                var NPC7 = new List<DialogData>();
                NPC7.Add(new DialogData("/emote:Smile/�������~ ���� �� ���� �� �ִ� ��ȭ���Դϴ�!", "Sandy"));
                var dialogData = new DialogData("Ȥ�� ã���ô� ������ �����Ű���?", "Sandy");
                dialogData.Callback = () => OpenShop();
                NPC7.Add(dialogData);
                DialogManager.Show(NPC7);
                break;
            #endregion
        }
    }

    void Check_Correct()
    {
        if(DialogManager.Result == "Correct")
        {
            Invoke("Deley", 1.8f);
            Fadein.SetActive(true);
            player.status.CurrentHP = player.status.MaxHP;
            player.status.CurrentMP = player.status.MaxMP;
            Invoke("invoke", 3f);
        }
        else if(DialogManager.Result == "Wrong")
        {
            var Cancel = new List<DialogData>();
            Cancel.Add(new DialogData("���� �׸�����.", "Gerda"));
            DialogManager.Show(Cancel);
        }
    }

    void Deley()
    {
        Healing_Bed.Play();
    }

    void invoke()
    {
        Fadein.SetActive(false);
        Fadeout.SetActive(true);
        Invoke("invoke1", 1.2f);
    }

    void invoke1()
    {
        var Heal = new List<DialogData>();
        Heal.Add(new DialogData("���� �������� �� ����!", "Gerda"));
        DialogManager.Show(Heal);
        Fadeout.SetActive(false);
    }

    #region SnowPrince
    void SnowPrince()
    {
        if(quest.QuestNum >= 18 && player.enemy.GetMonster < 3)
        {
            var NPC4 = new List<DialogData>();
            NPC4.Add(new DialogData("������ 3������ �����ΰ�?", "SnowPrince"));
            NPC4.Add(new DialogData("���ݸ� ��ٷ���!", "Gerda"));
            NPC4.Add(new DialogData("������ �ٲ�� ���� �ٳ���� �� ������.", "SnowPrince"));
            DialogManager.Show(NPC4);
        }
        else if(quest.QuestNum == 20 && player.enemy.GetMonster >= 3)
        {
            var NPC5 = new List<DialogData>();
            NPC5.Add(new DialogData("���� ��ƿ� ���� �����µ�.", "SnowPrince"));
            NPC5.Add(new DialogData("/emote:Hum/��, ���� ȥ�ڼ��� �� ������.", "Gerda"));
            NPC5.Add(new DialogData("/speed:down/.../speed:init/ �� �� ����. ����̴ϱ�.", "SnowPrince"));
            NPC5.Add(new DialogData("/emote:Smile/�ѽ�!", "Gerda"));
            NPC5.Add(new DialogData("�׷�, ������ ���� ������ ������ϴµ� �ٳ���ְڴ�?", "SnowPrince"));
            NPC5.Add(new DialogData("/emote:Hum/�� �ΰ�� �� ������ ���� �� �ƴϱ���?", "Gerda"));
            NPC5.Add(new DialogData("/emote:Sad/���� ��ġ�� ���� ���� �� ���̴ٸ�.", "SnowPrince"));
            NPC5.Add(new DialogData("�ƹ�ư, �� ������ �� �� ������ ������ �� ������� ���ھ�.", "SnowPrince"));
            NPC5.Add(new DialogData("���� ���ǰ� �Ķ� ���� ���� 3�����̸� �� �� ����.", "SnowPrince"));
            NPC5.Add(new DialogData("�׸��� ������ ���ư� �迡 ü���� ȸ���ؼ� ���ƿ��� \n�׶� ����ϱ�� ����.", "SnowPrince"));
            NPC5.Add(new DialogData("���� �˳��� ������ �������� ȸ���ص� �������.", "SnowPrince"));
            var dialogData1 = new DialogData("�˰ھ��. ��¦���� ��ٸ�����!", "Gerda");
            dialogData1.Callback = () => WhereShop();
            NPC5.Add(dialogData1);
            DialogManager.Show(NPC5);
            player.status.Coin += 120;
            quest.QuestNum++;
        }
        else if(quest.QuestNum == 21 && player.potion.HPPotion >= 3 && player.potion.MPPotion >= 3)
        {
            var NPC6 = new List<DialogData>();
            NPC6.Add(new DialogData("/emote:Smile/����. �� ������� �Ƚ��ϰ� ������ �� �ְھ�.", "SnowPrince"));
            NPC6.Add(new DialogData("/emote:Hum/�� ������ ���� �� �� ������?", "Gerda"));
            NPC6.Add(new DialogData("��, ��� ���� �� ���� ������.", "SnowPrince"));
            NPC6.Add(new DialogData("�׷� �� �غ�� �� ������ ������ ������. \nī�̴� ���� �ȿ��� ��ٸ��� �־�.", "SnowPrince"));
            var dialogData2 = new DialogData("/emote:Smile/���ƿ�! ���� ���~!", "Gerda");
            dialogData2.Callback = () => StartCoroutine(Ending());
            NPC6.Add(dialogData2);
            DialogManager.Show(NPC6);
            quest.QuestNum++;

        }
        else if(quest.QuestNum == 21 && (player.potion.HPPotion < 3 || player.potion.MPPotion < 3))
        {
            var NPC7 = new List<DialogData>();
            NPC7.Add(new DialogData("������ �����ΰ�?", "SnowPrince"));
            NPC7.Add(new DialogData("���� �˳��� �����ٵ�.", "SnowPrince"));
            NPC7.Add(new DialogData("/emote:Magic//speed:down/....../speed:init/", "SnowPrince"));
            NPC7.Add(new DialogData("/emote:Angry/���� ���� �ް� �� �����̶�� ����.", "SnowPrince"));
            NPC7.Add(new DialogData("/emote:Angry/�ٷ� ����ؾ� �ϴϱ�.", "SnowPrince"));
            DialogManager.Show(NPC7);
        }
        else if(quest.QuestNum == 16)
        {
            var NPC8 = new List<DialogData>();
            NPC8.Add(new DialogData("������ ������ �ִ� ������� ��ü ��� �ִ°ɱ��?", "Gerda"));
            NPC8.Add(new DialogData("�۽�. ������ �Ҹ��� �鸮�� �����̿� �ִ� �� Ȯ����.", "SnowPrince"));
            NPC8.Add(new DialogData("������ �������� �Ҹ��� ũ�� �︮�� �ʵ� �����Ѵٸ� �鸱����.", "SnowPrince"));
            DialogManager.Show(NPC8);
        }
        else if(quest.QuestNum == 17)
        {
            var NPC9 = new List<DialogData>();
            NPC9.Add(new DialogData("���� �츮�� ������ ������ ���ư���.", "SnowPrince"));
            NPC9.Add(new DialogData("�װ����� ������ Ÿ�� �̵��ؾ� �ϴϱ�.", "SnowPrince"));
            DialogManager.Show(NPC9);
        }
    }
    #endregion

    #region Shop
    void WhereShop()
    {
        whereShop.SetActive(true);
        var shop = new List<DialogData>();
        shop.Add(new DialogData("��ȭ���� �츮 ������ ���ʿ� �־�", "Gerda"));
        var dialogData3 = new DialogData("���� �˳��ϰ� �޾����� �ٳ�ͺ���?", "Gerda");
        dialogData3.Callback = () => HereShop();
        shop.Add(dialogData3);
        DialogManager.Show(shop);
    }

    void HereShop()
    {
        whereShop.SetActive(false);
    }

    void OpenShop()
    {
        ShopPannel.SetActive(true);
    }

    void HowPotion()
    {
        if(ShopPannel.activeSelf == true)
        {
            HpCount.text = player.potion.HPPotion.ToString();
            MpCount.text = player.potion.MPPotion.ToString();
        }
    }
    #endregion

    IEnumerator Ending()
    {
        Fadein.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Fadein.SetActive(false);
        SceneManager.LoadScene(8);
        Fadeout.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Fadeout.SetActive(false);
        yield return null;
    }
}
