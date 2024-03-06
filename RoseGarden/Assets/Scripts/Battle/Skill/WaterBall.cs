using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.Translate(Vector2.left * Time.deltaTime * 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("GameController"))
        {
            Destroy(gameObject);
        }
    }
}
