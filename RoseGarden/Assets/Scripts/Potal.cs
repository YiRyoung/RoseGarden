using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PotalNum { Potal1, Potal2, Potal3, Potal4, Potal5, Potal6, Potal7, Potal8, Potal9, Potal10, Potal11 }

public class Potal : MonoBehaviour
{
    public PotalNum potalNum;

    #region Transform_Position
    Vector2 livingRoom_Gerda = new Vector2(-3, -11);
    Vector2 Room_Gerda = new Vector2(-3, -2.9f);
    Vector2 House_Gerda = new Vector2(-0.6f, 0);
    Vector2 InHouse_Gerda = new Vector2(-3, -18.8f);
    Vector2 InHouse_Kai = new Vector2(-18f, -18.8f);
    Vector2 House_Kai = new Vector2(24.5f, 0.45f);
    Vector2 WHouse_Gerda = new Vector2(-0.5f, 0.5f);
    Vector2 InShop = new Vector2(0, -3);
    Vector2 FrontShop = new Vector2(-44.5f, -10.73f);
    Vector2 WHouse_Kai = new Vector2(24.5f, 0.45f);
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            switch (potalNum)
            {
                case PotalNum.Potal1:
                    collision.gameObject.transform.position = livingRoom_Gerda;
                    break;
                case PotalNum.Potal2:
                    collision.gameObject.transform.position = Room_Gerda;
                    break;
                case PotalNum.Potal3:
                    SceneManager.LoadScene(3);
                    collision.gameObject.transform.position = House_Gerda;
                    break;
                case PotalNum.Potal4:
                    SceneManager.LoadScene(2);
                    collision.gameObject.transform.position = InHouse_Gerda;
                    break;
                case PotalNum.Potal5:
                    SceneManager.LoadScene(4);
                    collision.gameObject.transform.position = InHouse_Kai;
                    break;
                case PotalNum.Potal6:
                    SceneManager.LoadScene(3);
                    collision.gameObject.transform.position = House_Kai;
                    break;
                case PotalNum.Potal7:
                    SceneManager.LoadScene(6);
                    collision.gameObject.transform.position = WHouse_Gerda;
                    break;
                case PotalNum.Potal8:
                    SceneManager.LoadScene(2);
                    collision.gameObject.transform.position = InHouse_Gerda;
                    break;
                case PotalNum.Potal9:
                    SceneManager.LoadScene(7);
                    collision.gameObject.transform.position = InShop;
                    break;
                case PotalNum.Potal10:
                    SceneManager.LoadScene(6);
                    collision.gameObject.transform.position = FrontShop;
                    break;
                case PotalNum.Potal11:
                    SceneManager.LoadScene(6);
                    collision.gameObject.transform.position = WHouse_Kai;
                    break;
            }
        }
    }
}
