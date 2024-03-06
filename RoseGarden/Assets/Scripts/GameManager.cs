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
                Object100.Add(new DialogData("푹신해보이는 침대다. 잠이 잘 올 것 같다.", "Gerda"));
                var object100 = new DialogData("조금 누워서 잘까?");
                object100.SelectList.Add("Correct", "좋아");
                object100.SelectList.Add("Wrong", "싫어");
                object100.Callback = () => Check_Correct();
                Object100.Add(object100);
                DialogManager.Show(Object100);
                break;
            case 101:
                var Object101 = new List<DialogData>();
                Object101.Add(new DialogData("일기장이 놓여있다.", "Gerda"));
                Object101.Add(new DialogData("여태 일어난 일을 기록할까?", "Gerda"));
                DialogManager.Show(Object101);
                break;
            case 102:
                var Object102 = new List<DialogData>();
                Object102.Add(new DialogData("다양한 책들이 꽂혀있다.", "Gerda"));
                Object102.Add(new DialogData("지금 내가 읽기엔 어려워보이는 것들도 꽤 있다.", "Gerda"));
                DialogManager.Show(Object102);
                break;
            case 103:
                var Object103 = new List<DialogData>();
                Object103.Add(new DialogData("옷가지가 가지런히 정리되어있다.", "Gerda"));
                DialogManager.Show(Object103);
                break;
            case 104:
                var Object104 = new List<DialogData>();
                Object104.Add(new DialogData("다양한 계절의 옷들이 깔끔하게 정리되어있다.", "Gerda"));
                DialogManager.Show(Object104);
                break;
            case 105:
                var Object105 = new List<DialogData>();
                Object105.Add(new DialogData("여러 종류의 차와 커피가 다기와 함께 전시되어있다.", "Gerda"));
                DialogManager.Show(Object105);
                break;
            case 106:
                var Object106 = new List<DialogData>();
                Object106.Add(new DialogData("냉장고 안에는 신선한 재료들이 보관되어있다.", "Gerda"));
                DialogManager.Show(Object106);
                break;
            case 107:
                var Object107 = new List<DialogData>();
                Object107.Add(new DialogData("싱크대에는 설거지거리 하나 없이 깨끗하다.", "Gerda"));
                Object107.Add(new DialogData("엄마가 설거지를 자주 해주시는 덕분이다.", "Gerda"));
                DialogManager.Show(Object107);
                break;

            case 120:
                var Object120 = new List<DialogData>();
                Object120.Add(new DialogData("사과가 달려있는 나무.", "Gerda"));
                Object120.Add(new DialogData("하지만 높이 달려있어서 딸 수 없어...", "Gerda"));
                DialogManager.Show(Object120);
                break;
            case 121:
                var Object121 = new List<DialogData>();
                Object121.Add(new DialogData("베리가 달려있는 덤불.", "Gerda"));
                Object121.Add(new DialogData("하지만 우리가 키운 게 아니야.", "Gerda"));
                DialogManager.Show(Object121);
                break;
            case 130:
                var Object130 = new List<DialogData>();
                Object130.Add(new DialogData("야생동물 주의!", "Announce"));
                DialogManager.Show(Object130);
                break;
            case 131:
                var Object131 = new List<DialogData>();
                Object131.Add(new DialogData("내가 만든 고양이 눈사람.", "Gerda"));
                Object131.Add(new DialogData("정성들여 만든만큼 귀엽다.", "Gerda"));
                DialogManager.Show(Object131);
                break;
            case 132:
                var Object132 = new List<DialogData>();
                Object132.Add(new DialogData("내가 만든 카이 눈사람.", "Gerda"));
                Object132.Add(new DialogData("/emote:Sad/저번 봄부터 틱틱대며 나와 안 놀아준다.", "Gerda"));
                Object132.Add(new DialogData("/emote:Sad/완전 미워! 못생긴 카이!", "Gerda"));
                Object132.Add(new DialogData("그래도 추울테니까 머플러는 둘러줬다.", "Gerda"));
                DialogManager.Show(Object132);
                break;
            case 133:
                var Object133 = new List<DialogData>();
                Object133.Add(new DialogData("짐을 실어놓은 마차.", "Gerda"));
                Object133.Add(new DialogData("오늘처럼 눈이 많이 쌓이면 썰매로 바꿔 사람을 운송하기도 한다.", "Gerda"));
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
                    NPC1.Add(new DialogData("무슨 일 있니?", "Mommy"));
                    NPC1.Add(new DialogData("그냥 불러봤어요.", "Gerda"));
                    NPC1.Add(new DialogData("필요한 일이 있다면 언제든지 부르렴.", "Mommy"));
                    DialogManager.Show(NPC1);
                break;
            case 1001:
                var NPC2 = new List<DialogData>();
                NPC2.Add(new DialogData("어머, 겔다 왔구나?", "KaiMom"));
                NPC2.Add(new DialogData("/emote:Smile/편히 놀다가 가렴.", "KaiMom"));
                DialogManager.Show(NPC2);
                break;
            case 1002:
                var NPC3 = new List<DialogData>();
                NPC3.Add(new DialogData("어어. 겔다 왔니?", "KaiDad"));
                NPC3.Add(new DialogData("/emote:Umm/......", "KaiDad"));
                NPC3.Add(new DialogData("/emote:Umm/미안, 아저씨가 지금 좀 바빠서...", "KaiDad"));
                DialogManager.Show(NPC3);
                break;
            case 1003:
                SnowPrince();
                break;
            case 1004:
                var NPC7 = new List<DialogData>();
                NPC7.Add(new DialogData("/emote:Smile/어서오세요~ 없는 거 빼고 다 있는 잡화점입니다!", "Sandy"));
                var dialogData = new DialogData("혹시 찾으시는 물건이 있으신가요?", "Sandy");
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
            Cancel.Add(new DialogData("역시 그만두자.", "Gerda"));
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
        Heal.Add(new DialogData("몸이 가벼워진 거 같아!", "Gerda"));
        DialogManager.Show(Heal);
        Fadeout.SetActive(false);
    }

    #region SnowPrince
    void SnowPrince()
    {
        if(quest.QuestNum >= 18 && player.enemy.GetMonster < 3)
        {
            var NPC4 = new List<DialogData>();
            NPC4.Add(new DialogData("슬라임 3마리는 아직인가?", "SnowPrince"));
            NPC4.Add(new DialogData("조금만 기다려요!", "Gerda"));
            NPC4.Add(new DialogData("마음이 바뀌기 전에 다녀오는 게 좋을걸.", "SnowPrince"));
            DialogManager.Show(NPC4);
        }
        else if(quest.QuestNum == 20 && player.enemy.GetMonster >= 3)
        {
            var NPC5 = new List<DialogData>();
            NPC5.Add(new DialogData("정말 잡아올 줄은 몰랐는데.", "SnowPrince"));
            NPC5.Add(new DialogData("/emote:Hum/헹, 절대 혼자서는 못 보내죠.", "Gerda"));
            NPC5.Add(new DialogData("/speed:down/.../speed:init/ 할 수 없지. 약속이니까.", "SnowPrince"));
            NPC5.Add(new DialogData("/emote:Smile/앗싸!", "Gerda"));
            NPC5.Add(new DialogData("그럼, 떠나기 전에 상점에 들려야하는데 다녀와주겠니?", "SnowPrince"));
            NPC5.Add(new DialogData("/emote:Hum/그 핑계로 저 버리고 가는 거 아니구요?", "Gerda"));
            NPC5.Add(new DialogData("/emote:Sad/상점 위치를 몰라서 못간 것 뿐이다만.", "SnowPrince"));
            NPC5.Add(new DialogData("아무튼, 긴 여행이 될 수 있으니 포션을 좀 사왔으면 좋겠어.", "SnowPrince"));
            NPC5.Add(new DialogData("붉은 포션과 파란 포션 각각 3개쯤이면 될 것 같네.", "SnowPrince"));
            NPC5.Add(new DialogData("그리고 마을에 돌아간 김에 체력을 회복해서 돌아오면 \n그때 출발하기로 하지.", "SnowPrince"));
            NPC5.Add(new DialogData("돈은 넉넉히 줬으니 포션으로 회복해도 상관없고.", "SnowPrince"));
            var dialogData1 = new DialogData("알겠어요. 꼼짝말고 기다리세요!", "Gerda");
            dialogData1.Callback = () => WhereShop();
            NPC5.Add(dialogData1);
            DialogManager.Show(NPC5);
            player.status.Coin += 120;
            quest.QuestNum++;
        }
        else if(quest.QuestNum == 21 && player.potion.HPPotion >= 3 && player.potion.MPPotion >= 3)
        {
            var NPC6 = new List<DialogData>();
            NPC6.Add(new DialogData("/emote:Smile/좋아. 이 정도라면 안심하고 데려갈 수 있겠어.", "SnowPrince"));
            NPC6.Add(new DialogData("/emote:Hum/이 포션이 전부 다 제 꺼라고요?", "Gerda"));
            NPC6.Add(new DialogData("뭐, 적어도 내가 쓸 일은 없겠지.", "SnowPrince"));
            NPC6.Add(new DialogData("그럼 다 준비된 거 같으니 마차에 오르렴. \n카이는 마차 안에서 기다리고 있어.", "SnowPrince"));
            var dialogData2 = new DialogData("/emote:Smile/좋아요! 드디어 출발~!", "Gerda");
            dialogData2.Callback = () => StartCoroutine(Ending());
            NPC6.Add(dialogData2);
            DialogManager.Show(NPC6);
            quest.QuestNum++;

        }
        else if(quest.QuestNum == 21 && (player.potion.HPPotion < 3 || player.potion.MPPotion < 3))
        {
            var NPC7 = new List<DialogData>();
            NPC7.Add(new DialogData("물약은 아직인가?", "SnowPrince"));
            NPC7.Add(new DialogData("돈은 넉넉히 줬을텐데.", "SnowPrince"));
            NPC7.Add(new DialogData("/emote:Magic//speed:down/....../speed:init/", "SnowPrince"));
            NPC7.Add(new DialogData("/emote:Angry/만약 돈만 받고 말 생각이라면 말해.", "SnowPrince"));
            NPC7.Add(new DialogData("/emote:Angry/바로 출발해야 하니까.", "SnowPrince"));
            DialogManager.Show(NPC7);
        }
        else if(quest.QuestNum == 16)
        {
            var NPC8 = new List<DialogData>();
            NPC8.Add(new DialogData("조각을 가지고 있는 사람들은 대체 어디에 있는걸까요?", "Gerda"));
            NPC8.Add(new DialogData("글쎄. 하지만 소리가 들리니 가까이에 있는 건 확실해.", "SnowPrince"));
            NPC8.Add(new DialogData("가까이 있을수록 소리가 크게 울리니 너도 집중한다면 들릴지도.", "SnowPrince"));
            DialogManager.Show(NPC8);
        }
        else if(quest.QuestNum == 17)
        {
            var NPC9 = new List<DialogData>();
            NPC9.Add(new DialogData("이제 우리가 만났던 곳으로 돌아가자.", "SnowPrince"));
            NPC9.Add(new DialogData("그곳에서 마차를 타고 이동해야 하니까.", "SnowPrince"));
            DialogManager.Show(NPC9);
        }
    }
    #endregion

    #region Shop
    void WhereShop()
    {
        whereShop.SetActive(true);
        var shop = new List<DialogData>();
        shop.Add(new DialogData("잡화점은 우리 집에서 왼쪽에 있어", "Gerda"));
        var dialogData3 = new DialogData("돈도 넉넉하게 받았으니 다녀와볼까?", "Gerda");
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
