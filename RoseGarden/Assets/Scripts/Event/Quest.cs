using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Quest : MonoBehaviour
{
    #region DontDestroy
    void Awake()
    {
        var obj = FindObjectsOfType<Player>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [Header("Quest Number")]
    public int QuestNum; //퀘스트진행도

    [Header("StroyEvent")]
    //StoryEvent11//
    public GameObject SnowPrince;
    public GameObject Effect1;
    [HideInInspector]
    GameObject kai;

    //StoryEvent13//
    bool Found1;
    bool Found2;
    #region Villiagers
    [System.Serializable]
    public struct Villiagers
    {
        public GameObject Group1;
        public GameObject Group2;
        public GameObject Group3;
        public GameObject Group4;
        public GameObject Group5;
        public GameObject Group6;
        public GameObject Guy;
    }

    public Villiagers villiagers;
    #endregion

    [Space (10f)]
    public DialogManager DialogManager;
    public GameObject DialogPrint;
    public GameObject KeyGuide;
    public GameObject ChapterPanel;
    public GameObject Fadein;
    public GameObject Fadeout;
    public Player player;

    void Start()
    {
        Found1 = false;
        Found2 = false;
        QuestNum = 0;
        DialogPrint.SetActive(false);
        KeyGuide.SetActive(false);
        SnowPrince.SetActive(false);
        if (QuestNum != 0)
        {
            CancelPanel();
        }
        else if (QuestNum == 0)
        {
            Invoke("CancelPanel", 5f);
        }
        else
        {
            ChapterPanel = null;
        }

        Invoke("QuestSc", 4.7f);
    }

    void Update()
    {
        if (QuestNum >= 7)
        {
            kai = GameObject.FindGameObjectWithTag("Kai");
            if (kai != null)
            {
                Destroy(kai);
            }
            else
            {
                return;
            }
        }
    }

    void CancelPanel()
    {
        ChapterPanel.SetActive(false);
    }

    #region QuestScripts
    #region StoryEvent0
    void QuestSc()
    {
        DialogPrint.SetActive(true);
        if (QuestNum == 0)
        {
            var dialog0 = new List<DialogData>();
            dialog0.Add(new DialogData("앗.. 벌써 시간이 이렇게 됐네.", "Gerda"));
            dialog0.Add(new DialogData("곧 있으면 카이를 만나기로 한 시간이야.", "Gerda"));
            dialog0.Add(new DialogData("방향키를 이용해서 카이를 만나러가자.", "Gerda"));
            var dialogData = new DialogData("카이는 분명 집 앞에 있는 공터에서 기다리고 있을거야.", "Gerda");
            dialogData.Callback = () => Lastlog1();

            dialog0.Add(dialogData);

            DialogManager.Show(dialog0);
        }
        else
        {
            DialogPrint.SetActive(false);
        }
    }

    void Lastlog1()
    {
        QuestNum++;
        KeyGuide.SetActive(true);
    }
    #endregion

    #region StroyEvent1
    public void StoryEvent1()
    {
        var dialog1 = new List<DialogData>();
        dialog1.Add(new DialogData("어머, 카이 만나러가니?", "Mommy"));
        dialog1.Add(new DialogData("조심히 늦지 않게 다녀오렴.", "Mommy"));
        dialog1.Add(new DialogData("네, 다녀올게요!", "Gerda"));

        DialogManager.Show(dialog1);
        QuestNum++; // 2
    }
    #endregion

    #region StoryEvent3
    public void StoryEvent3()
    {
        var dialog4 = new List<DialogData>();
        dialog4.Add(new DialogData("/emote:Angry/가까이서 봐도 보이는 건 없어...", "Gerda"));
        dialog4.Add(new DialogData("/emote:Angry/우선 집으로 돌아가서 쉴래?", "Gerda"));
        dialog4.Add(new DialogData("/emote:Cool/아니, 필요없어.", "Kai"));
        dialog4.Add(new DialogData("/emote:Cool/집에 갈래.", "Kai"));
        var dialogData2 = new DialogData("/emote:Sad/카이...?", "Gerda");
        dialogData2.Callback = () => Nextlog();
        dialog4.Add(dialogData2);
        DialogManager.Show(dialog4);
    }

    public void Nextlog()
    {
        kai = GameObject.FindGameObjectWithTag("Kai");
        if (kai != null)
        {
            Destroy(kai);
        }
        else
        {
            return;
        }
        var dialog5 = new List<DialogData>();
        dialog5.Add(new DialogData("/emote:Sad/대체 무슨 일이지... \n 우선 시간이 늦었으니 나도 집으로 돌아가야겠어.", "Gerda"));
        dialog5.Add(new DialogData("/emote:Angry/카이가 괜찮은지 내일 확인해보자.", "Gerda"));
        DialogManager.Show(dialog5);
        QuestNum++; //5
    }
    #endregion

    #region StoryEvent6
    public void StoryEvent6()
    {
        var dialog10 = new List<DialogData>();
        dialog10.Add(new DialogData("/emote:Angry/방금 무슨 소리지?", "Gerda"));
        dialog10.Add(new DialogData("/emote:Angry/어서 들어가보자.", "Gerda"));
        DialogManager.Show(dialog10);
        QuestNum++; //9
    }
    #endregion

    #region StoryEvent8
    public void StroyEvent8()
    {
        var dialog13 = new List<DialogData>();
        dialog13.Add(new DialogData("지금 카이를 만나는 건 좋은 생각이 아니야.", "Gerda"));
        DialogManager.Show(dialog13);
    }
    #endregion

    #region StoryEvent10
    public void StoryEvent10()
    {
        var dialog17 = new List<DialogData>();
        dialog17.Add(new DialogData("좋아, 아직 멀쩡하게 잘 있어!", "Gerda"));
        dialog17.Add(new DialogData("음.../wait:0.7/ 주변에서 할 만한 건 다 한 거 같은데...", "Gerda"));
        dialog17.Add(new DialogData("아직 안 밟힌 눈을 따라가볼까?", "Gerda"));
        dialog17.Add(new DialogData("위로 가면 사람들이 자주 안가는 숲이 있어.", "Gerda"));
        dialog17.Add(new DialogData("깊이 들어가면 위험할테니까 입구 근처까지만 가보자.", "Gerda"));
        DialogManager.Show(dialog17);
        QuestNum++;
    }
    #endregion

    #region StoryEvent11
    public void StroyEvent11()
    {
        var Effect1 = new List<DialogData>();
        Effect1.Add(new DialogData("우와... 유리조각인가?", "Gerda"));
        Effect1.Add(new DialogData("/emote:Smile/엄청 반짝거려..!", "Gerda"));
        var dialogData = new DialogData("집에 가져갈까?", "Gerda");
        dialogData.Callback = () => LastLog();
        Effect1.Add(dialogData);
        DialogManager.Show(Effect1);
    }
    void LastLog()
    {
        SnowPrince.transform.position = new Vector2(player.transform.position.x, (player.transform.position.y + 1.5f));
        SnowPrince.SetActive(true);
        Effect1.SetActive(false);
        Talk();
        QuestNum++;
    }

    void Talk()
    {
        var dialog20 = new List<DialogData>();
        dialog20.Add(new DialogData("/emote:Magic/멈춰!", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Sad/우왓?! 누구세요?", "Gerda"));
        dialog20.Add(new DialogData("나는 너희들이 눈의 왕자라고 부르는 사람.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Sad/정말 할머니께서 말씀해주셨던 분이세요?", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/그럼.. 혹시 전에 카이가 했던 말도...", "Gerda"));
        dialog20.Add(new DialogData("걱정 마. 난 그저 악마의 거울조각을 회수하러 왔을 뿐이니까.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Angry/악마의 거울조각이요?", "Gerda"));
        dialog20.Add(new DialogData("요즘 마을 사람들 중에 갑자기 폭력적으로 변한 사람이 있었을텐데.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Angry/아..! 카이와 몇몇 마을사람들!", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/그들이 갑자기 변한 이유는 이게 몸 속에 박혔기 때문이야.", "SnowPrince"));
        dialog20.Add(new DialogData("나는 더 이상 피해자가 늘지 않도록 그것을 회수하고 있어.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Smile/나한테는 아무 효과도 없거든.", "SnowPrince"));
        dialog20.Add(new DialogData("그럼..! 사람들을 원래대로 돌아오게 하는 방법도 알고 있나요?", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/아니. 찾아보고 있는 중이지만 진척이 없어.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Sad/앗... 그렇군요.", "Gerda"));
        dialog20.Add(new DialogData("혹시 제가 도울 일은 없을까요?", "Gerda"));
        dialog20.Add(new DialogData("/emote:Angry/마음은 고맙지만 필요없어.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Sad/거울조각 때문에 저희 마을은 엉망진창이 되었어요!", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/제 가장 친한 친구도 마찬가지고요...", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/사람들 모두 며칠 지나면 괜찮아질 거라고 믿어왔지만 " +
            "\n 상황은 전혀 나아지지 않았어요.", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/제발 부탁드려요! 제가 도울 일이 없을까요?", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad//speed:down/.../speed:up/ 그렇다면 이상이 있는 마을사람들을 알려주겠니?", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Magic/그냥 냅두는 것보단 내 성에 데려가서 " +
            "거울 조각을 \n빼낼 방법을 찾는 게 더 좋겠지.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Smile/네! 최대한 도울게요!", "Gerda"));
        dialog20.Add(new DialogData("/emote:Magic/거울조각이 박힌 사람들은 공명음을 낼 거야. " +
            "\n 아마 네게도 들릴테니 찾는 건 어렵지 않겠지.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Magic/좋아, 마을은 어느 쪽이지?", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Smile/네! 마을은 이쪽이에요!", "Gerda"));
        DialogManager.Show(dialog20);
    }
    #endregion

    #region StroyEvent13
    public void Quest1()
    {
        var quest1 = new List<DialogData>();
        quest1.Add(new DialogData("오늘은 여기까지만 하고 이만 들어갈까?", "OldWoman"));
        quest1.Add(new DialogData("조금만 더 놀고 싶은데/speed:down/.../speed:init/", "Girl"));
        quest1.Add(new DialogData("추울까봐 따뜻하게 스튜를 만들어놨는데도?", "OldWoman"));
        var dialogData1 = new DialogData("집으로 돌아가요!", "Girl");
        dialogData1.Callback = () => Invoke("Next1", 1.2f);
        quest1.Add(dialogData1);
        DialogManager.Show(quest1);
    }
    public void Next1()
    {
        Destroy(villiagers.Group1, 0.7f);
        var next1 = new List<DialogData>();
        next1.Add(new DialogData("아무 소리도 들리지 않아.", "SnowPrince"));
        next1.Add(new DialogData("이분들은 아닌가 봐요.", "Gerda"));
        next1.Add(new DialogData("그래, 거울 조각이 박히면 온도가 낮은 것을 좋아하는 경향이 있어.", "SnowPrince"));
        next1.Add(new DialogData("그래서 카이도 매일 썰매를 타러 나갔구나/speed:down/.../speed:init/", "Gerda"));
        next1.Add(new DialogData("뭐, 아무튼 다른 사람들을 찾아보자.", "SnowPrince"));
        DialogManager.Show(next1);
    }

    public void Quest2()
    {
        var quest2 = new List<DialogData>();
        quest2.Add(new DialogData("대체 갑자기 왜 그러시는거에요!!", "Man"));
        quest2.Add(new DialogData("더는 찾아오지 말라고 했지!!", "OldWoman"));
        quest2.Add(new DialogData("훔쳐가는 게 아니고 날이 추워서 걱정되서 온거라니까요?!", "Man"));
        quest2.Add(new DialogData("그딴 변명 안 통한다! 썩 꺼져!", "OldMan"));
        quest2.Add(new DialogData("아, 알겠어요! 알겠다고요!", "Man"));
        var dialogData2 = new DialogData("갑자기 뭘 잘못드셨길래 저러신담/speed:down/.../speed:init/", "Man");
        dialogData2.Callback = () => Invoke("Next2", 1.2f);
        quest2.Add(dialogData2);
        DialogManager.Show(quest2);
    }

    public void Next2()
    {
        var next2 = new List<DialogData>();
        next2.Add(new DialogData("아무래도 여긴가보군.", "SnowPrince"));
        next2.Add(new DialogData("아! 저한테도 소리가 들리는거 같아요!", "Gerda"));
        next2.Add(new DialogData("금실이 좋았던 모양이야. 조각을 사이좋게 나눠갖다니.", "SnowPrince"));
        next2.Add(new DialogData("하지만 이대로는 자식과의 관계가 상하겠어요.", "Gerda"));
        var dialogData4 = new DialogData("어쩔 수 없지. 대충 설명하고 데려가자.", "SnowPrince");
        dialogData4.Callback = () => Invoke("Next4", 1.2f);
        next2.Add(dialogData4);
        DialogManager.Show(next2);
    }

    public void Next4()
    {
        Destroy(villiagers.Group2);
        Found1 = true;
        var next4 = new List<DialogData>();
        var dialogData5 = new DialogData("이제 이 근처에는 없는 거 같아.", "SnowPrince");
        dialogData5.Callback = () => Next5();
        next4.Add(dialogData5);
        DialogManager.Show(next4);
    }

    public void Next5()
    {
        if(Found2 == false)
        {
            var next5 = new List<DialogData>();
            next5.Add(new DialogData("다른 구역으로 이동할까.", "SnowPrince"));
            next5.Add(new DialogData("이번엔 왼쪽 구역으로 가봐요!", "Gerda"));
            DialogManager.Show(next5);
        }
        else if(Found2 == true)
        {
            var next6 = new List<DialogData>();
            next6.Add(new DialogData("전부 찾은 것 같으니 우리가 만났던 곳으로 돌아가지.", "SnowPrince"));
            DialogManager.Show(next6);
            QuestNum++;
        }
    }

    public void Quest3()
    {
        var quest3 = new List<DialogData>();
        quest3.Add(new DialogData("눈이 소복하게 쌓였네~", "OldWoman"));
        quest3.Add(new DialogData("날도 추운데 집에 있지 왜 나오자고 하는지, 원/speed:down/.../speed:init/", "OldMan"));
        var dialogData3 = new DialogData("어휴! 춥다고 집에만 있으면 병 나!", "OldWoman");
        dialogData3.Callback = () => Invoke("Next3", 1.2f);
        quest3.Add(dialogData3);
        DialogManager.Show(quest3);
    }

    public void Next3()
    {
        Destroy(villiagers.Group3, 0.7f);
        var next3 = new List<DialogData>();
        next3.Add(new DialogData("날씨가 쌀쌀한데도 따뜻해보이시네.", "SnowPrince"));
        next3.Add(new DialogData("이곳에서도 소리는 들리지 않았어요.", "Gerda"));
        next3.Add(new DialogData("조각을 가지고 있는 사람이 적다는 건 좋은 일이지.", "SnowPrince"));
        next3.Add(new DialogData("다른 곳을 찾아보자.", "SnowPrince"));
        DialogManager.Show(next3);
    }

    public void Quest4()
    {
        var quest4 = new List<DialogData>();
        quest4.Add(new DialogData("우와! 이제 정말 겨울인가봐~ 눈이 엄청 쌓였네?", "Woman"));
        quest4.Add(new DialogData("그러게. 어제도 눈은 왔었지만 이 정도는 아니었던 거 같은데.", "Man"));
        quest4.Add(new DialogData("저쪽에 누가 귀여운 눈사람을 만들어놨던데, 우리도 만들까?", "Woman"));
        var dialogData6 = new DialogData("좋아, 그럼 우리는 크게 만들어보자고.", "Man");
        dialogData6.Callback = () => Invoke("Next6", 1.2f);
        quest4.Add(dialogData6);
        DialogManager.Show(quest4);
    }

    public void Next6()
    {
        Destroy(villiagers.Group4, 0.7f);
        var next7 = new List<DialogData>();
        next7.Add(new DialogData("사이좋은 연인이네요.", "Gerda"));
        next7.Add(new DialogData("다른 곳을 둘러봐야겠어.", "SnowPrince"));
        DialogManager.Show(next7);
    }

    public void Quest5()
    {
        var quest5 = new List<DialogData>();
        quest5.Add(new DialogData("어휴. 갑자기 눈이 이리 쌓이네요/speed:down/.../speed:init/", "Woman"));
        quest5.Add(new DialogData("그러게나 말이야. 어머님, 힘드시지 않으세요?", "Man"));
        quest5.Add(new DialogData("괜찮다. 어차피 곧 집 앞인데 뭘.", "OldWoman"));
        var dialogData7 = new DialogData("집에 도착하면 물부터 따뜻하게 데워놓을게요.", "Woman");
        dialogData7.Callback = () => Invoke("Next7", 1.2f);
        quest5.Add(dialogData7);
        DialogManager.Show(quest5);
    }

    public void Next7()
    {
        Destroy(villiagers.Group5, 0.7f);
        var next8 = new List<DialogData>();
        next8.Add(new DialogData("어디 놀러갔다 오시는 분들인가봐요", "Gerda"));
        next8.Add(new DialogData("그래, 오붓해보이는 걸 보니 저곳에 조각은 없겠어.", "SnowPrince"));
        DialogManager.Show(next8);
    }

    public void Quest6()
    {
        var quest6 = new List<DialogData>();
        quest6.Add(new DialogData("와! 눈이다, 눈!", "Girl"));
        quest6.Add(new DialogData("눈싸움하자, 눈싸움!", "Boy"));
        var dialogData8 = new DialogData("많이 맞은 사람이 정리 다하기~!", "Girl");
        dialogData8.Callback = () => Invoke("Next8", 1.2f);
        quest6.Add(dialogData8);
        DialogManager.Show(quest6);
    }

    public void Next8()
    {
        Destroy(villiagers.Group6, 0.7f);
        var next9 = new List<DialogData>();
        next9.Add(new DialogData("여긴 그냥 눈을 좋아하는 애들이군.",  "SnowPrince"));
        next9.Add(new DialogData("그러게요. 굉장히 즐거워보여요.",  "Gerda"));
        next9.Add(new DialogData("원한다면 안내는 여기까지하고 가서 놀아도 되는데.",  "SnowPrince"));
        next9.Add(new DialogData("그럴 수는 없죠.",  "Gerda"));
        DialogManager.Show(next9);
    }

    public void Quest7()
    {
        var quest7 = new List<DialogData>();
        quest7.Add(new DialogData("저기, 저 남자애 지금 남의 집에 눈덩이 던지고 있는거에요?!", "Gerda"));
        var dialogData9 = new DialogData("아무래도 조각을 가지고 있는 사람이 저 아이인가보네.", "SnowPrince");
        dialogData9.Callback = () => Invoke("Next9", 1.2f);
        quest7.Add(dialogData9);
        DialogManager.Show(quest7);
    }
    public void Next9()
    {
        Destroy(villiagers.Guy);
        Found2 = true;
        var next10 = new List<DialogData>();
        var dialogData10 = new DialogData("이제 이 근처에는 없는 거 같아.", "SnowPrince");
        dialogData10.Callback = () => Next10();
        next10.Add(dialogData10);
        DialogManager.Show(next10);
    }

    public void Next10()
    {
        if (Found1 == false)
        {
            var next11 = new List<DialogData>();
            next11.Add(new DialogData("다른 구역으로 이동할까.", "SnowPrince"));
            next11.Add(new DialogData("이번엔 밑으로 가봐요!", "Gerda"));
            DialogManager.Show(next11);
        }
        else if (Found1 == true)
        {
            var next12 = new List<DialogData>();
            next12.Add(new DialogData("전부 찾은 것 같으니 우리가 만났던 곳으로 돌아가지.", "SnowPrince"));
            DialogManager.Show(next12);
            QuestNum++;
        }
    }
    #endregion
    #endregion
}
