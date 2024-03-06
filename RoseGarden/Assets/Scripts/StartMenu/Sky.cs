using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Sky : MonoBehaviour
{
    public GameObject DaySky;
    public GameObject NightSky;
    public GameObject Snow;
    public TextMeshProUGUI clockText;

    public GameObject DayTitle;
    public GameObject NightTitle;

    // 시간에 따라 배경 바꾸기
    static string Hour = DateTime.Now.ToString("HH");
    static string Min = DateTime.Now.ToString("mm");
    static string Sec = DateTime.Now.ToString("ss");
    int DateNum = Convert.ToInt32(Hour);
    int ClockNum = Convert.ToInt32(Hour + Min + Sec);

    void Start()
    {
        //디지털 시계
        StartCoroutine(Clock());
        //폰트 색상을 회색으로
        GameObject.Find("Clock").GetComponent<TextMeshProUGUI>().color = Color.gray;

        //랜덤하게 눈이 내리도록
        Snow.SetActive(false);
        int isSnowy = UnityEngine.Random.Range(0, 5);
        Debug.Log(isSnowy);
        if (isSnowy == 0)
        {
            Snow.SetActive(true);
        }

        // 시간에 따른 배경 출력 7-7
        if (DateNum >= 07 && DateNum < 19)
        {
            DaySky.SetActive(true);
            DayTitle.SetActive(true);
            NightSky.SetActive(false);
            NightTitle.SetActive(false);
        }
        else if (DateNum >= 19 && DateNum <= 24)
        {
            NightSky.SetActive(true);
            NightTitle.SetActive(true);
            DaySky.SetActive(false);
            DayTitle.SetActive(false);
        }
        else if (DateNum >= 0 && DateNum < 7)
        {
            NightSky.SetActive(true);
            NightTitle.SetActive(true);
            DaySky.SetActive(false);
            DayTitle.SetActive(false);
        }
    }

    void Update()
    {
        //특정 시간이 되면 배경 바꿔주기
        if (ClockNum == 055959)
        {
            NightSky.SetActive(false);
            NightTitle.SetActive(false);
            DaySky.SetActive(true);
            DayTitle.SetActive(true);
        }
        else if (ClockNum == 205959)
        {
            NightSky.SetActive(true);
            NightTitle.SetActive(true);
            DaySky.SetActive(false);
            DayTitle.SetActive(false);
        }
    }

    void GetTime()
    {
        clockText.text = DateTime.Now.ToString(("yyyy-MM-dd \n HH:mm:ss"));
    }
    IEnumerator Clock()
    {
        while(true)
        {
            GetTime();
            yield return new WaitForSeconds(1);
        }
    }
}
