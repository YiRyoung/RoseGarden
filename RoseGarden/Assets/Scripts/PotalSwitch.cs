using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalSwitch : MonoBehaviour
{
    public Quest quest;
    public GameObject p3;
    public GameObject p7;

    void Start()
    {
        p7.SetActive(false);
    }

    void Update()
    {
        if (quest.QuestNum >= 10)
        {
            p3.SetActive(false);
            p7.SetActive(true);
        }
    }
}
