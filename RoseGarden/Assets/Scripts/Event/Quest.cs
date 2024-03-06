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
    public int QuestNum; //����Ʈ���൵

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
            dialog0.Add(new DialogData("��.. ���� �ð��� �̷��� �Ƴ�.", "Gerda"));
            dialog0.Add(new DialogData("�� ������ ī�̸� ������� �� �ð��̾�.", "Gerda"));
            dialog0.Add(new DialogData("����Ű�� �̿��ؼ� ī�̸� ����������.", "Gerda"));
            var dialogData = new DialogData("ī�̴� �и� �� �տ� �ִ� ���Ϳ��� ��ٸ��� �����ž�.", "Gerda");
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
        dialog1.Add(new DialogData("���, ī�� ����������?", "Mommy"));
        dialog1.Add(new DialogData("������ ���� �ʰ� �ٳ����.", "Mommy"));
        dialog1.Add(new DialogData("��, �ٳ�ðԿ�!", "Gerda"));

        DialogManager.Show(dialog1);
        QuestNum++; // 2
    }
    #endregion

    #region StoryEvent3
    public void StoryEvent3()
    {
        var dialog4 = new List<DialogData>();
        dialog4.Add(new DialogData("/emote:Angry/�����̼� ���� ���̴� �� ����...", "Gerda"));
        dialog4.Add(new DialogData("/emote:Angry/�켱 ������ ���ư��� ����?", "Gerda"));
        dialog4.Add(new DialogData("/emote:Cool/�ƴ�, �ʿ����.", "Kai"));
        dialog4.Add(new DialogData("/emote:Cool/���� ����.", "Kai"));
        var dialogData2 = new DialogData("/emote:Sad/ī��...?", "Gerda");
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
        dialog5.Add(new DialogData("/emote:Sad/��ü ���� ������... \n �켱 �ð��� �ʾ����� ���� ������ ���ư��߰ھ�.", "Gerda"));
        dialog5.Add(new DialogData("/emote:Angry/ī�̰� �������� ���� Ȯ���غ���.", "Gerda"));
        DialogManager.Show(dialog5);
        QuestNum++; //5
    }
    #endregion

    #region StoryEvent6
    public void StoryEvent6()
    {
        var dialog10 = new List<DialogData>();
        dialog10.Add(new DialogData("/emote:Angry/��� ���� �Ҹ���?", "Gerda"));
        dialog10.Add(new DialogData("/emote:Angry/� ������.", "Gerda"));
        DialogManager.Show(dialog10);
        QuestNum++; //9
    }
    #endregion

    #region StoryEvent8
    public void StroyEvent8()
    {
        var dialog13 = new List<DialogData>();
        dialog13.Add(new DialogData("���� ī�̸� ������ �� ���� ������ �ƴϾ�.", "Gerda"));
        DialogManager.Show(dialog13);
    }
    #endregion

    #region StoryEvent10
    public void StoryEvent10()
    {
        var dialog17 = new List<DialogData>();
        dialog17.Add(new DialogData("����, ���� �����ϰ� �� �־�!", "Gerda"));
        dialog17.Add(new DialogData("��.../wait:0.7/ �ֺ����� �� ���� �� �� �� �� ������...", "Gerda"));
        dialog17.Add(new DialogData("���� �� ���� ���� ���󰡺���?", "Gerda"));
        dialog17.Add(new DialogData("���� ���� ������� ���� �Ȱ��� ���� �־�.", "Gerda"));
        dialog17.Add(new DialogData("���� ���� �������״ϱ� �Ա� ��ó������ ������.", "Gerda"));
        DialogManager.Show(dialog17);
        QuestNum++;
    }
    #endregion

    #region StoryEvent11
    public void StroyEvent11()
    {
        var Effect1 = new List<DialogData>();
        Effect1.Add(new DialogData("���... ���������ΰ�?", "Gerda"));
        Effect1.Add(new DialogData("/emote:Smile/��û ��¦�ŷ�..!", "Gerda"));
        var dialogData = new DialogData("���� ��������?", "Gerda");
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
        dialog20.Add(new DialogData("/emote:Magic/����!", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Sad/���?! ��������?", "Gerda"));
        dialog20.Add(new DialogData("���� ������� ���� ���ڶ�� �θ��� ���.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Sad/���� �ҸӴϲ��� �������̴ּ� ���̼���?", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/�׷�.. Ȥ�� ���� ī�̰� �ߴ� ����...", "Gerda"));
        dialog20.Add(new DialogData("���� ��. �� ���� �Ǹ��� �ſ������� ȸ���Ϸ� ���� ���̴ϱ�.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Angry/�Ǹ��� �ſ������̿�?", "Gerda"));
        dialog20.Add(new DialogData("���� ���� ����� �߿� ���ڱ� ���������� ���� ����� �־����ٵ�.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Angry/��..! ī�̿� ��� ���������!", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/�׵��� ���ڱ� ���� ������ �̰� �� �ӿ� ������ �����̾�.", "SnowPrince"));
        dialog20.Add(new DialogData("���� �� �̻� �����ڰ� ���� �ʵ��� �װ��� ȸ���ϰ� �־�.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Smile/�����״� �ƹ� ȿ���� ���ŵ�.", "SnowPrince"));
        dialog20.Add(new DialogData("�׷�..! ������� ������� ���ƿ��� �ϴ� ����� �˰� �ֳ���?", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/�ƴ�. ã�ƺ��� �ִ� �������� ��ô�� ����.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Sad/��... �׷�����.", "Gerda"));
        dialog20.Add(new DialogData("Ȥ�� ���� ���� ���� �������?", "Gerda"));
        dialog20.Add(new DialogData("/emote:Angry/������ ������ �ʿ����.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Sad/�ſ����� ������ ���� ������ ������â�� �Ǿ����!", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/�� ���� ģ�� ģ���� �����������...", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/����� ��� ��ĥ ������ �������� �Ŷ�� �Ͼ������ " +
            "\n ��Ȳ�� ���� �������� �ʾҾ��.", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad/���� ��Ź�����! ���� ���� ���� �������?", "Gerda"));
        dialog20.Add(new DialogData("/emote:Sad//speed:down/.../speed:up/ �׷��ٸ� �̻��� �ִ� ����������� �˷��ְڴ�?", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Magic/�׳� ���δ� �ͺ��� �� ���� �������� " +
            "�ſ� ������ \n���� ����� ã�� �� �� ������.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Smile/��! �ִ��� ����Կ�!", "Gerda"));
        dialog20.Add(new DialogData("/emote:Magic/�ſ������� ���� ������� �������� �� �ž�. " +
            "\n �Ƹ� �װԵ� �鸱�״� ã�� �� ����� �ʰ���.", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Magic/����, ������ ��� ������?", "SnowPrince"));
        dialog20.Add(new DialogData("/emote:Smile/��! ������ �����̿���!", "Gerda"));
        DialogManager.Show(dialog20);
    }
    #endregion

    #region StroyEvent13
    public void Quest1()
    {
        var quest1 = new List<DialogData>();
        quest1.Add(new DialogData("������ ��������� �ϰ� �̸� ����?", "OldWoman"));
        quest1.Add(new DialogData("���ݸ� �� ��� ������/speed:down/.../speed:init/", "Girl"));
        quest1.Add(new DialogData("�߿��� �����ϰ� ��Ʃ�� �������µ���?", "OldWoman"));
        var dialogData1 = new DialogData("������ ���ư���!", "Girl");
        dialogData1.Callback = () => Invoke("Next1", 1.2f);
        quest1.Add(dialogData1);
        DialogManager.Show(quest1);
    }
    public void Next1()
    {
        Destroy(villiagers.Group1, 0.7f);
        var next1 = new List<DialogData>();
        next1.Add(new DialogData("�ƹ� �Ҹ��� �鸮�� �ʾ�.", "SnowPrince"));
        next1.Add(new DialogData("�̺е��� �ƴѰ� ����.", "Gerda"));
        next1.Add(new DialogData("�׷�, �ſ� ������ ������ �µ��� ���� ���� �����ϴ� ������ �־�.", "SnowPrince"));
        next1.Add(new DialogData("�׷��� ī�̵� ���� ��Ÿ� Ÿ�� ��������/speed:down/.../speed:init/", "Gerda"));
        next1.Add(new DialogData("��, �ƹ�ư �ٸ� ������� ã�ƺ���.", "SnowPrince"));
        DialogManager.Show(next1);
    }

    public void Quest2()
    {
        var quest2 = new List<DialogData>();
        quest2.Add(new DialogData("��ü ���ڱ� �� �׷��ô°ſ���!!", "Man"));
        quest2.Add(new DialogData("���� ã�ƿ��� ����� ����!!", "OldWoman"));
        quest2.Add(new DialogData("���İ��� �� �ƴϰ� ���� �߿��� �����Ǽ� �°Ŷ�ϱ��?!", "Man"));
        quest2.Add(new DialogData("�׵� ���� �� ���Ѵ�! �� ����!", "OldMan"));
        quest2.Add(new DialogData("��, �˰ھ��! �˰ڴٰ��!", "Man"));
        var dialogData2 = new DialogData("���ڱ� �� �߸���̱淡 �����Ŵ�/speed:down/.../speed:init/", "Man");
        dialogData2.Callback = () => Invoke("Next2", 1.2f);
        quest2.Add(dialogData2);
        DialogManager.Show(quest2);
    }

    public void Next2()
    {
        var next2 = new List<DialogData>();
        next2.Add(new DialogData("�ƹ����� ���䰡����.", "SnowPrince"));
        next2.Add(new DialogData("��! �����׵� �Ҹ��� �鸮�°� ���ƿ�!", "Gerda"));
        next2.Add(new DialogData("�ݽ��� ���Ҵ� ����̾�. ������ �������� �������ٴ�.", "SnowPrince"));
        next2.Add(new DialogData("������ �̴�δ� �ڽİ��� ���谡 ���ϰھ��.", "Gerda"));
        var dialogData4 = new DialogData("��¿ �� ����. ���� �����ϰ� ��������.", "SnowPrince");
        dialogData4.Callback = () => Invoke("Next4", 1.2f);
        next2.Add(dialogData4);
        DialogManager.Show(next2);
    }

    public void Next4()
    {
        Destroy(villiagers.Group2);
        Found1 = true;
        var next4 = new List<DialogData>();
        var dialogData5 = new DialogData("���� �� ��ó���� ���� �� ����.", "SnowPrince");
        dialogData5.Callback = () => Next5();
        next4.Add(dialogData5);
        DialogManager.Show(next4);
    }

    public void Next5()
    {
        if(Found2 == false)
        {
            var next5 = new List<DialogData>();
            next5.Add(new DialogData("�ٸ� �������� �̵��ұ�.", "SnowPrince"));
            next5.Add(new DialogData("�̹��� ���� �������� ������!", "Gerda"));
            DialogManager.Show(next5);
        }
        else if(Found2 == true)
        {
            var next6 = new List<DialogData>();
            next6.Add(new DialogData("���� ã�� �� ������ �츮�� ������ ������ ���ư���.", "SnowPrince"));
            DialogManager.Show(next6);
            QuestNum++;
        }
    }

    public void Quest3()
    {
        var quest3 = new List<DialogData>();
        quest3.Add(new DialogData("���� �Һ��ϰ� �׿���~", "OldWoman"));
        quest3.Add(new DialogData("���� �߿ ���� ���� �� �����ڰ� �ϴ���, ��/speed:down/.../speed:init/", "OldMan"));
        var dialogData3 = new DialogData("����! ��ٰ� ������ ������ �� ��!", "OldWoman");
        dialogData3.Callback = () => Invoke("Next3", 1.2f);
        quest3.Add(dialogData3);
        DialogManager.Show(quest3);
    }

    public void Next3()
    {
        Destroy(villiagers.Group3, 0.7f);
        var next3 = new List<DialogData>();
        next3.Add(new DialogData("������ �ҽ��ѵ��� �����غ��̽ó�.", "SnowPrince"));
        next3.Add(new DialogData("�̰������� �Ҹ��� �鸮�� �ʾҾ��.", "Gerda"));
        next3.Add(new DialogData("������ ������ �ִ� ����� ���ٴ� �� ���� ������.", "SnowPrince"));
        next3.Add(new DialogData("�ٸ� ���� ã�ƺ���.", "SnowPrince"));
        DialogManager.Show(next3);
    }

    public void Quest4()
    {
        var quest4 = new List<DialogData>();
        quest4.Add(new DialogData("���! ���� ���� �ܿ��ΰ���~ ���� ��û �׿���?", "Woman"));
        quest4.Add(new DialogData("�׷���. ������ ���� �Ծ����� �� ������ �ƴϾ��� �� ������.", "Man"));
        quest4.Add(new DialogData("���ʿ� ���� �Ϳ��� ������� ����������, �츮�� �����?", "Woman"));
        var dialogData6 = new DialogData("����, �׷� �츮�� ũ�� �����ڰ�.", "Man");
        dialogData6.Callback = () => Invoke("Next6", 1.2f);
        quest4.Add(dialogData6);
        DialogManager.Show(quest4);
    }

    public void Next6()
    {
        Destroy(villiagers.Group4, 0.7f);
        var next7 = new List<DialogData>();
        next7.Add(new DialogData("�������� �����̳׿�.", "Gerda"));
        next7.Add(new DialogData("�ٸ� ���� �ѷ����߰ھ�.", "SnowPrince"));
        DialogManager.Show(next7);
    }

    public void Quest5()
    {
        var quest5 = new List<DialogData>();
        quest5.Add(new DialogData("����. ���ڱ� ���� �̸� ���̳׿�/speed:down/.../speed:init/", "Woman"));
        quest5.Add(new DialogData("�׷��Գ� ���̾�. ��Ӵ�, ������� ��������?", "Man"));
        quest5.Add(new DialogData("������. ������ �� �� ���ε� ��.", "OldWoman"));
        var dialogData7 = new DialogData("���� �����ϸ� ������ �����ϰ� ���������Կ�.", "Woman");
        dialogData7.Callback = () => Invoke("Next7", 1.2f);
        quest5.Add(dialogData7);
        DialogManager.Show(quest5);
    }

    public void Next7()
    {
        Destroy(villiagers.Group5, 0.7f);
        var next8 = new List<DialogData>();
        next8.Add(new DialogData("��� ����� ���ô� �е��ΰ�����", "Gerda"));
        next8.Add(new DialogData("�׷�, �����غ��̴� �� ���� ������ ������ ���ھ�.", "SnowPrince"));
        DialogManager.Show(next8);
    }

    public void Quest6()
    {
        var quest6 = new List<DialogData>();
        quest6.Add(new DialogData("��! ���̴�, ��!", "Girl"));
        quest6.Add(new DialogData("���ο�����, ���ο�!", "Boy"));
        var dialogData8 = new DialogData("���� ���� ����� ���� ���ϱ�~!", "Girl");
        dialogData8.Callback = () => Invoke("Next8", 1.2f);
        quest6.Add(dialogData8);
        DialogManager.Show(quest6);
    }

    public void Next8()
    {
        Destroy(villiagers.Group6, 0.7f);
        var next9 = new List<DialogData>();
        next9.Add(new DialogData("���� �׳� ���� �����ϴ� �ֵ��̱�.",  "SnowPrince"));
        next9.Add(new DialogData("�׷��Կ�. ������ ��ſ�������.",  "Gerda"));
        next9.Add(new DialogData("���Ѵٸ� �ȳ��� ��������ϰ� ���� ��Ƶ� �Ǵµ�.",  "SnowPrince"));
        next9.Add(new DialogData("�׷� ���� ����.",  "Gerda"));
        DialogManager.Show(next9);
    }

    public void Quest7()
    {
        var quest7 = new List<DialogData>();
        quest7.Add(new DialogData("����, �� ���ھ� ���� ���� ���� ������ ������ �ִ°ſ���?!", "Gerda"));
        var dialogData9 = new DialogData("�ƹ����� ������ ������ �ִ� ����� �� �����ΰ�����.", "SnowPrince");
        dialogData9.Callback = () => Invoke("Next9", 1.2f);
        quest7.Add(dialogData9);
        DialogManager.Show(quest7);
    }
    public void Next9()
    {
        Destroy(villiagers.Guy);
        Found2 = true;
        var next10 = new List<DialogData>();
        var dialogData10 = new DialogData("���� �� ��ó���� ���� �� ����.", "SnowPrince");
        dialogData10.Callback = () => Next10();
        next10.Add(dialogData10);
        DialogManager.Show(next10);
    }

    public void Next10()
    {
        if (Found1 == false)
        {
            var next11 = new List<DialogData>();
            next11.Add(new DialogData("�ٸ� �������� �̵��ұ�.", "SnowPrince"));
            next11.Add(new DialogData("�̹��� ������ ������!", "Gerda"));
            DialogManager.Show(next11);
        }
        else if (Found1 == true)
        {
            var next12 = new List<DialogData>();
            next12.Add(new DialogData("���� ã�� �� ������ �츮�� ������ ������ ���ư���.", "SnowPrince"));
            DialogManager.Show(next12);
            QuestNum++;
        }
    }
    #endregion
    #endregion
}
