using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPrince : MonoBehaviour
{
    public Player player;
    public Quest quest;
    Animator anim;
    Rigidbody2D rid;
    public float MoveSpeed;
    public readonly int posX = Animator.StringToHash("posX");
    public readonly int posY = Animator.StringToHash("posY");
    public readonly int isMove = Animator.StringToHash("isMove");

    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MoveSpeed = 3.7f;
    }
    void Update()
    {
        if(quest.QuestNum >= 15 && quest.QuestNum <= 17)
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
                anim.SetFloat(posX, h);
                anim.SetFloat(posY, v);
                anim.SetBool(isMove, true);
                gameObject.transform.position = new Vector2(player.transform.position.x, (player.transform.position.y + 1.5f));
                transform.Translate((player.transform.position).normalized * MoveSpeed * Time.deltaTime);
            }
            else
            {
                anim.SetBool(isMove, false);
            }
        }

        if(quest.QuestNum >= 18)
        {
            rid.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
