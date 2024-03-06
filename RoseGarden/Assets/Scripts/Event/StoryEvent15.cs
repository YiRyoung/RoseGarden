using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StoryEvent15 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Player player;
    public Quest quest;
    public GameObject Event;
    public GameObject prince;

    void Update()
    {
        if((player.state == BattleState.WAIT) && (quest.QuestNum == 18) && (player.enemy.GetMonster == 3))
        {
            quest.QuestNum++;
            Invoke("Talk", 0.7f);
        }
        else if(quest.QuestNum >= 20)
        {
            Destroy(Event);
        }
    }

    void Talk()
    {
        var dialog24 = new List<DialogData>();
        dialog24.Add(new DialogData("좋아! 슬라임 3마리를 모두 잡았어!", "Gerda"));
        var dialogData = new DialogData("그가 떠나버리기 전에 어서 돌아가자!", "Gerda");
        dialogData.Callback = () => Next();
        dialog24.Add(dialogData);
        DialogManager.Show(dialog24);
    }

    void Next()
    {
        quest.QuestNum++;
    }
}
