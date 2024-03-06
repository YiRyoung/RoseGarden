using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSilme : MonoBehaviour
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

    public GameObject player;
    Rigidbody2D rid;

    [Header("Animation")]
    //Animation
    Animator anim;
    public readonly int Die = Animator.StringToHash("Die");
    public readonly int Hurtig = Animator.StringToHash("Hurting");
    public readonly int Attack = Animator.StringToHash("Attack");

    [Space (10f)]
    [Header("Status")]
    //Status
    public float MaxHP = 7;
    public float CurrentHP = 7;
    public float STR = 1;
    public float DEX = 1.2f;
    public float GiveExp = 3;
    public int GiveCoin = 2;

    [Space(10f)]
    [Header("Battle")]
    public GameObject WaterBall;
    public GameObject WaterBlast;
    public AudioSource SWaterBall;
    public AudioSource SWaterBlast;


    //Public Method
    #region Skill_M
    //Skill
    public void WATERBLAST()
    {
        SWaterBlast.Play();
        Instantiate<GameObject>(WaterBlast, new Vector2(109.4f, 2.6f), Quaternion.identity);
    }

    public void WATERBALL()
    {
        SWaterBall.Play();
        Instantiate<GameObject>(WaterBall, new Vector2(119.2f, 2.35f), Quaternion.identity);
    }

    public void HURT()
    {
        anim.SetTrigger(Hurtig);
    }
    #endregion

    void Start()
    {
        anim = GetComponent<Animator>();
        rid = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //Min_Status
        if(CurrentHP < 0)
        {
            CurrentHP = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Respawn"))
        {
            this.CurrentHP -= player.GetComponent<Player>().status.STR;
        }
        else if(collision.gameObject.CompareTag("Lighting"))
        {
            this.CurrentHP -= player.GetComponent<Player>().status.STR * 2.5f;
        }
    }
}
