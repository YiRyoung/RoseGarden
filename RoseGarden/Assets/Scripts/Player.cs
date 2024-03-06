using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { WAIT, START, PLAYERTURN, MONSTERTURN, WIN, LOSE }

public class Player : MonoBehaviour
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

    #region Non_BattleInit
    [Header("Non_Battle")]
    //Move
    Rigidbody2D rid;
    public GameObject printer;
    public float MoveSpeed;

    //ScanObject
    public GameManager gameManager;
    Vector3 dirVec;
    GameObject scanObject;

    //Animation
    public Animator anim;
    public readonly int posX = Animator.StringToHash("posX");
    public readonly int posY = Animator.StringToHash("posY");
    public readonly int isMove = Animator.StringToHash("isMove");
    public readonly int Read = Animator.StringToHash("Read");
    #endregion

    #region Audio Source
    [System.Serializable]
    public struct Sound
    {
        public AudioSource ClickP;
        public AudioSource Healing_Potion;
        public AudioSource win;
        public AudioSource lose;
        public AudioSource Levelup;
        public AudioSource FireBall;
        public AudioSource FireBird;
    }
    public Sound sound;
    #endregion

    #region StatusInit
    [System.Serializable]
    public struct Status
    {
        //Status
        public GameObject StatusScreen;
        public float CurrentHP; //체력
        public float MaxHP;
        public Image HPbar;
        public float CurrentMP; //스테미나
        public float MaxMP;
        public Image MPbar;
        public float Exp; //경험치
        public float MaxExp;
        public Image EXPbar;
        public float STR; //공격력
        public float DEX; //민첩
        public int LV;
        public int Coin;
    }

    [System.Serializable]
    public struct StatusTexts
    {
        //Status Text
        public TextMeshProUGUI StatusHP;
        public TextMeshProUGUI StatusMP;
        public TextMeshProUGUI StatusEXP;
        public TextMeshProUGUI StatusLV;
        public TextMeshProUGUI StatusCoin;
        public TextMeshProUGUI StatusSTR;
        public TextMeshProUGUI StatusDEX;
    }

    [System.Serializable]
    public struct Potion
    {
        public int HPPotion;
        public int MPPotion;

        [Space (8f)]
        public GameObject HPicon_empty;
        public GameObject MPicon_empty;
        public GameObject HPicon;
        public GameObject MPicon;
        public TextMeshProUGUI HPcount;
        public TextMeshProUGUI MPcount;

        [Space(8f)]
        //Battle
        public GameObject HpIconB_empty;
        public GameObject MpIconB_empty;
        public GameObject HpIconB;
        public GameObject MpIconB;
        public TextMeshProUGUI HpCountB;
        public TextMeshProUGUI MpCountB;
    }

    [Header("Status")]
    public Status status;
    public StatusTexts statusTexts;
    public Potion potion;
    #endregion

    #region BattleInit
    [Header("Battle")]
    public GameObject Fadein;
    public GameObject Fadeout;
    public GameObject BattleUI;
    public GameObject BattleCam;
    [HideInInspector]
    public BattleState state;
    int Run;

    [System.Serializable]
    public struct Skill
    {
        //SkillInit
        public GameObject Attack;
        public GameObject Lighting;
        public GameObject AttackButton;
        public GameObject LightingButton;

        [Space(10f)]
        public GameObject PotionPannel;
        public GameObject PotionButton;
        public GameObject HpPotionButton;
        public GameObject MpPotionButton;
        public GameObject RunAwayButton;
    }

    public Skill skill;

    [System.Serializable]
    public struct Enemy
    {
        //Monster
        public GameObject Monster;
        public int GetMonster;
        public Image HPbar_M;
        public TextMeshProUGUI HP_M;
        [HideInInspector]
        public int SkillNum_M;
    }
    public Enemy enemy;
    #endregion

    //Private Method//
    #region Move
    void Move()
    {
        //Move
        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && printer.activeSelf == false)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            anim.SetFloat(posX, h);
            anim.SetFloat(posY, v);
            anim.SetBool(isMove, true);
            Vector2 movement = new Vector2(h, v);
            transform.Translate(movement.normalized * MoveSpeed * Time.deltaTime);
        }
    }
    #endregion

    #region ScanObject
    void Scaning()
    {
        //Ray
        Debug.DrawRay(transform.position, dirVec * 1.2f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rid.position, dirVec, 1.2f, LayerMask.GetMask("Map"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }

        //Direction
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            dirVec = Vector3.up;
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            dirVec = Vector3.down;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            dirVec = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            dirVec = Vector3.right;

        //Scan Object
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (scanObject == null)
            {
                return;
            }
            else if (scanObject != null)
            {
                gameManager.Action(scanObject);
            }
        }
    }
    #endregion

    #region StatusWindow
    //스테이터스 창
    void StatusShow()
    {
        statusTexts.StatusHP.text = status.CurrentHP + "/" + status.MaxHP;
        status.HPbar.fillAmount = status.CurrentHP / status.MaxHP;
        statusTexts.StatusMP.text = status.CurrentMP + "/" + status.MaxMP;
        status.MPbar.fillAmount = status.CurrentMP / status.MaxMP;
        statusTexts.StatusLV.text = "Lv: " + status.LV;
        statusTexts.StatusEXP.text = status.Exp + "/" + status.MaxExp;
        status.EXPbar.fillAmount = status.Exp / status.MaxExp;
        statusTexts.StatusSTR.text = status.STR.ToString();
        statusTexts.StatusDEX.text = status.DEX.ToString();
        statusTexts.StatusCoin.text = status.Coin.ToString();

        if(Input.GetKeyDown(KeyCode.P))
        {
            sound.ClickP.Play();
            status.StatusScreen.SetActive(!status.StatusScreen.activeSelf);
        }
    }
    #endregion

    #region PotionWindow
    void PotionShow()
    {
        if(potion.HPPotion == 0)
        {
            potion.HPcount.text = "0";
            potion.HPicon_empty.SetActive(true);
            potion.HPicon.SetActive(false);
        }
        else
        {
            potion.HPcount.text = potion.HPPotion.ToString();
            potion.HPicon_empty.SetActive(false);
            potion.HPicon.SetActive(true);
        }

        if(potion.MPPotion == 0)
        {
            potion.MPcount.text = "0";
            potion.MPicon_empty.SetActive(true);
            potion.MPicon.SetActive(false);
        }
        else
        {
            potion.MPcount.text = potion.MPPotion.ToString();
            potion.MPicon_empty.SetActive(false);
            potion.MPicon.SetActive(true);
        }
    }

    void PotionShow_B()
    {
        if(state == BattleState.PLAYERTURN)
        {
            if (potion.HPPotion == 0)
            {
                potion.HpCountB.text = "0";
                potion.HpIconB_empty.SetActive(true);
                potion.HpIconB.SetActive(false);
            }
            else
            {
                potion.HpCountB.text = potion.HPPotion.ToString();
                potion.HpIconB_empty.SetActive(false);
                potion.HpIconB.SetActive(true);
            }

            if(potion.MPPotion == 0)
            {
                potion.MpCountB.text = "0";
                potion.MpIconB_empty.SetActive(true);
                potion.MpIconB.SetActive(false);
            }
            else
            {
                potion.MpCountB.text = potion.MPPotion.ToString();
                potion.MpIconB_empty.SetActive(false);
                potion.MpIconB.SetActive(true);
            }
        }
    }
    #endregion

    #region LevelUp
    void LevelUp()
    {
        if (status.Exp >= status.MaxExp)
        {
            sound.Levelup.Play();
            status.LV++;
            status.Exp = status.Exp - status.MaxExp;
            Levelup();
        }
    }

    void Levelup()
    {
        switch (status.LV)
        {
            case 2:
                status.MaxHP += 3;
                status.MaxMP += 3;
                status.MaxExp += 15;
                status.STR++;
                status.DEX += 0.3f;
                break;
        }
    }
    #endregion

    #region Status_M
    void Status_M()
    {
        if (state != BattleState.WAIT)
        {
            enemy.HPbar_M.fillAmount = enemy.Monster.GetComponent<BlueSilme>().CurrentHP / enemy.Monster.GetComponent<BlueSilme>().MaxHP;
            enemy.HP_M.text = enemy.Monster.GetComponent<BlueSilme>().CurrentHP + "/" + enemy.Monster.GetComponent<BlueSilme>().MaxHP;
        }
    }
    #endregion

    #region BattleBase
    //BattleState
    void battleState()
    {
        switch (state)
        {
            case BattleState.WAIT:
                WAIT();
                break;
            case BattleState.START:
                START();
                break;
            case BattleState.PLAYERTURN:
                break;
            case BattleState.MONSTERTURN:
                MONSTERTURN();
                break;
            case BattleState.WIN:
                WIN();
                break;
            case BattleState.LOSE:
                LOSE();
                break;
        }
    }

    //Wait -> Start
    //Wait에서 넘어갈 시 플레이어 이동 X
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            enemy.Monster = collision.gameObject;
            Fadein.SetActive(true);
            state = BattleState.START;
            StartCoroutine(BattleStart());
        }
    }
    IEnumerator BattleStart()
    {
        BattleCam.SetActive(true);
        enemy.Monster.transform.position = new Vector2(119.2f, 2.35f);
        yield return new WaitForSeconds(1.2f);
        Fadein.SetActive(false);
        Fadeout.SetActive(true);
        BattleUI.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Fadeout.SetActive(false);
        skill.AttackButton = GameObject.Find("Attack");
        skill.LightingButton = GameObject.Find("Lighting");
        yield break;
    }

    //WAIT
    void WAIT()
    {
        BattleUI.SetActive(false);
        BattleCam.SetActive(false);
    }

    //START
    void START()
    {
        if (this.status.DEX >= enemy.Monster.GetComponent<BlueSilme>().DEX)
        {
            skill.AttackButton.GetComponent<Button>().interactable = true;
            skill.LightingButton.GetComponent<Button>().interactable = true;
            skill.PotionButton.GetComponent<Button>().interactable = true;
            skill.RunAwayButton.GetComponent<Button>().interactable = true;
            state = BattleState.PLAYERTURN;
        }
        else if (this.status.DEX < enemy.Monster.GetComponent<BlueSilme>().DEX)
        {
            state = BattleState.MONSTERTURN;
        }
    }

    void PlayerTurn()
    {
        if ((enemy.Monster.GetComponent<BlueSilme>().CurrentHP) > 0)
        {
            state = BattleState.MONSTERTURN;
        }
        else if ((enemy.Monster.GetComponent<BlueSilme>().CurrentHP) <= 0)
        {
            state = BattleState.WIN;
        }
    }

    void MONSTERTURN()
    {
        if (enemy.SkillNum_M == 3)
        {
            enemy.Monster.GetComponent<BlueSilme>().WATERBLAST();
            this.status.CurrentHP -= 3;
            if (this.status.CurrentHP > 0)
            {
                state = BattleState.PLAYERTURN;
                skill.AttackButton.GetComponent<Button>().interactable = true;
                skill.LightingButton.GetComponent<Button>().interactable = true;
                skill.PotionButton.GetComponent<Button>().interactable = true;
                skill.RunAwayButton.GetComponent<Button>().interactable = true;
            }
            else if (this.status.CurrentHP <= 0)
            {
                state = BattleState.LOSE;
            }
        }
        else
        {
            enemy.Monster.GetComponent<BlueSilme>().WATERBALL();
            this.status.CurrentHP -= 1;
            if (this.status.CurrentHP > 0)
            {
                state = BattleState.PLAYERTURN;
                skill.AttackButton.GetComponent<Button>().interactable = true;
                skill.LightingButton.GetComponent<Button>().interactable = true;
                skill.PotionButton.GetComponent<Button>().interactable = true;
                skill.RunAwayButton.GetComponent<Button>().interactable = true;
            }
            else if (this.status.CurrentHP <= 0)
            {
                state = BattleState.LOSE;
            }
        }
    }

    void WIN()
    {
        StartCoroutine(Win());
    }
    IEnumerator Win()
    {
        sound.win.Play();
        this.status.Exp += enemy.Monster.GetComponent<BlueSilme>().GiveExp;
        this.status.Coin += enemy.Monster.GetComponent<BlueSilme>().GiveCoin;
        enemy.GetMonster++;
        BattleUI.SetActive(false);
        BattleCam.SetActive(false);
        Destroy(enemy.Monster);
        enemy.Monster = null;
        Fadein.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Fadein.SetActive(false);
        Fadeout.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Fadeout.SetActive(false);
        state = BattleState.WAIT;
        yield break;
    }

    void LOSE()
    {
        StartCoroutine(Lose());
    }
    IEnumerator Lose()
    {
        sound.lose.Play();
        Fadein.SetActive(true);
        state = BattleState.WAIT;
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(2);
        this.gameObject.transform.position = new Vector2(0, 0);
        status.CurrentHP = 1;
        BattleUI.SetActive(false);
        BattleCam.SetActive(false);
        Destroy(enemy.Monster);
        enemy.Monster = null;
        Fadein.SetActive(false);
        Fadeout.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Fadeout.SetActive(false);

    }

    #endregion

    //Public Method//

    #region Skill(On_Click)
    public void Attack_Skill()
    {
        if (status.CurrentMP >= 1)
        {
            sound.FireBall.Play();
            Instantiate<GameObject>(skill.Attack, new Vector2(109.4f, 2.6f), Quaternion.identity);
            status.CurrentMP -= 1;
            skill.AttackButton.GetComponent<Button>().interactable = false;
            skill.LightingButton.GetComponent<Button>().interactable = false;
            skill.PotionButton.GetComponent<Button>().interactable = false;
            skill.RunAwayButton.GetComponent<Button>().interactable = false;
            Invoke("PlayerTurn", 1.2f);
        }
    }

    public void Lighting_Skill()
    {
        if (status.CurrentMP >= 7)
        {
            sound.FireBird.Play();
            Instantiate<GameObject>(skill.Lighting, new Vector2(110f, 2.6f), Quaternion.identity);
            status.CurrentMP -= 7;
            skill.AttackButton.GetComponent<Button>().interactable = false;
            skill.LightingButton.GetComponent<Button>().interactable = false;
            skill.PotionButton.GetComponent<Button>().interactable = false;
            skill.RunAwayButton.GetComponent<Button>().interactable = false;
            Invoke("PlayerTurn", 1.2f);
        }
    }
    #endregion

    #region Potion_Battle(On_Click)
    public void PotionPannel_B()
    {
        skill.PotionPannel.SetActive(!skill.PotionPannel.activeSelf);
    }

    public void HpPotion_B()
    {
        StartCoroutine(HpPotion_b());
    }

    IEnumerator HpPotion_b()
    {
        if (potion.HPPotion > 0)
        {
            sound.Healing_Potion.Play();
            potion.HPPotion--;
            status.CurrentHP += 15;
            skill.AttackButton.GetComponent<Button>().interactable = false;
            skill.LightingButton.GetComponent<Button>().interactable = false;
            skill.PotionPannel.SetActive(false);
            skill.PotionButton.GetComponent<Button>().interactable = false;
            skill.RunAwayButton.GetComponent<Button>().interactable = false;
        }
        yield return new WaitForSeconds(0.3f);
        state = BattleState.MONSTERTURN;
        yield return null;
    }

    public void MpPotion_B()
    {
        StartCoroutine(MpPotion_b());
    }

    IEnumerator MpPotion_b()
    {
        if (potion.MPPotion > 0)
        {
            sound.Healing_Potion.Play();
            potion.MPPotion--;
            status.CurrentMP += 15;
            skill.AttackButton.GetComponent<Button>().interactable = false;
            skill.LightingButton.GetComponent<Button>().interactable = false;
            skill.PotionPannel.SetActive(false);
            skill.PotionButton.GetComponent<Button>().interactable = false;
            skill.RunAwayButton.GetComponent<Button>().interactable = false;
        }
        yield return new WaitForSeconds(0.3f);
        state = BattleState.MONSTERTURN;
        yield return null;
    }
    #endregion

    #region Potion(On_Click)
    public void HP_Potion()
    {
        if(potion.HPPotion > 0)
        {
            sound.Healing_Potion.Play();
            potion.HPPotion--;
            status.CurrentHP += 15;
        }
    }

    public void MP_Potion()
    {
        if(potion.MPPotion > 0)
        {
            sound.Healing_Potion.Play();
            potion.MPPotion--;
            status.CurrentMP += 15;
        }
    }
    #endregion

    #region RunAway(On_Click)
    public void RunAway()
    {
        Run = UnityEngine.Random.Range(0, 10);
        if (Run < 7)
        {
            StartCoroutine(Runaway());
        }
        else
        {
            StartCoroutine(Runaway_Fail());
        }
    }

    IEnumerator Runaway()
    {
        sound.lose.Play();
        Fadein.SetActive(true);
        BattleUI.SetActive(false);
        Destroy(enemy.Monster);
        yield return new WaitForSeconds(1.2f);
        Fadein.SetActive(false);
        this.gameObject.transform.position = new Vector2(12.38f, 49.35f);
        state = BattleState.WAIT;
        Fadeout.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Fadeout.SetActive(false);
        yield return null;
    }

    IEnumerator Runaway_Fail()
    {
        skill.AttackButton.GetComponent<Button>().interactable = false;
        skill.LightingButton.GetComponent<Button>().interactable = false;
        skill.PotionPannel.SetActive(false);
        skill.PotionButton.GetComponent<Button>().interactable = false;
        skill.RunAwayButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(0.3f);
        state = BattleState.MONSTERTURN;
        yield return null;
    }
    #endregion

    void Start()
    {
        #region Status_Init
        status.StatusScreen.SetActive(false);
        status.LV = 1; //레벨
        status.CurrentHP = 15; //체력
        status.MaxHP = 15;
        status.CurrentMP = 15; //스테미나
        status.MaxMP = 15;
        status.STR = 2; //공격력
        status.DEX = 1.5f; //민첩
        status.Exp = 0; //경험치
        status.MaxExp = 15; //경험치
        status.Coin = 0;
        MoveSpeed = 5f;
        potion.HPPotion = 0;
        potion.MPPotion = 0;
        #endregion

        #region Battle_Init
        Fadein.SetActive(false);
        Fadeout.SetActive(false);
        BattleUI.SetActive(false);
        BattleCam.SetActive(false);
        skill.PotionPannel.SetActive(false);
        enemy.GetMonster = 0;
        enemy.Monster = null;
        enemy.Monster = GameObject.FindWithTag("Monster");
        #endregion

        anim = GetComponent<Animator>();
        rid = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        #region Min_Status
        if(status.CurrentHP < 0)
        {
            status.CurrentHP = 0;
        }
        else if(status.CurrentHP > status.MaxHP)
        {
            status.CurrentHP = status.MaxHP;
        }

        if(status.CurrentMP < 0)
        {
            status.CurrentMP = 0;
        }
        else if(status.CurrentMP > status.MaxMP)
        {
            status.CurrentMP = status.MaxMP;
        }
        #endregion

        #region Button Interactive
        //Button Interactive
        if (this.status.CurrentMP < 7 && state != BattleState.WAIT)
        {
            skill.LightingButton.GetComponent<Button>().interactable = false;
        }
        
        if(this.status.CurrentMP < 1 && state != BattleState.WAIT)
        {
            skill.AttackButton.GetComponent<Button>().interactable = false;
        }

        if (potion.HPPotion <= 0 && state != BattleState.WAIT)
        {
            potion.HPPotion = 0;
            potion.HpIconB.SetActive(false);
            potion.HpIconB_empty.SetActive(true);
        }
        else if (potion.MPPotion <= 0 && state != BattleState.WAIT)
        {
            potion.MPPotion = 0;
            potion.MpIconB.SetActive(false);
            potion.MpIconB_empty.SetActive(true);
        }
        #endregion

        //MonsterSkill(Random)
        enemy.SkillNum_M = UnityEngine.Random.Range(0, 4);

        Move();
        Scaning();
        StatusShow();
        LevelUp();
        PotionShow();
        PotionShow_B();
        Status_M();
        battleState();
    }

    void LateUpdate()
    {
        if (posX != 0 || posY != 0)
        {
            anim.SetBool(isMove, false);
        }
    }
}

