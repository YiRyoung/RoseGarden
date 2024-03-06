using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleStatus : MonoBehaviour
{
    public Player player;
    public Image HPbar;
    public Image MPbar;
    public TextMeshProUGUI Hp;
    public TextMeshProUGUI Mp;

    void Update()
    {
        Hp.text = player.status.CurrentHP + "/" + player.status.MaxHP;
        HPbar.fillAmount = player.status.CurrentHP / player.status.MaxHP;
        Mp.text = player.status.CurrentMP + "/" + player.status.MaxMP;
        MPbar.fillAmount = player.status.CurrentMP / player.status.MaxMP;
    }
}
