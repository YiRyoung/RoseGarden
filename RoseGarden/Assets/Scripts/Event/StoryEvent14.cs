using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StoryEvent14 : MonoBehaviour
{
    public DialogManager DialogManager;
    public Player player;
    public SnowPrince snowprince;
    public Quest quest;
    public GameObject Event;
    public GameObject Fadein;
    public GameObject FadeOut;
    public GameObject Effect;
    public GameObject prince;
    public GameObject timeline;

    void Start()
    {
        timeline.SetActive(false);
        Fadein.SetActive(false);
        FadeOut.SetActive(false);
        Effect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && quest.QuestNum == 17)
        {
            Fadein.SetActive(true);
            Invoke("Fade", 1.2f);
        }
        if (quest.QuestNum >= 18)
        {
            Destroy(Event);
        }
    }
    
    void Fade()
    {
        player.transform.position = new Vector2(5.3f, 33.4f);
        snowprince.transform.position = new Vector2(5.3f, 34.4f);
        Fadein.SetActive(false);
        FadeOut.SetActive(true);
        Invoke("Talk", 1.2f);
    }
    void Talk()
    {
        FadeOut.SetActive(false);
        var dialog22 = new List<DialogData>();
        dialog22.Add(new DialogData("근처에 카이가 있는 듯 하니 이쯤에서 헤어지면 될 거 같네.", "SnowPrince"));
        dialog22.Add(new DialogData("여기까지 도움 고마웠어, 겔다.", "SnowPrince"));
        dialog22.Add(new DialogData("이대로 가시려구요? 저도 끝까지 도울래요!", "Gerda"));
        dialog22.Add(new DialogData("여기까진 멀지 않으니까 허락했지만 더 이상은 안 돼.", "SnowPrince"));
        dialog22.Add(new DialogData("이 숲도 위험해서 들어오지 말라는 경고판이 있었을텐데.", "SnowPrince"));
        dialog22.Add(new DialogData("썰매 끝에 매달려서라도 따라갈거에요!", "Gerda"));
        dialog22.Add(new DialogData("/emote:Hum/솔직히, 마을 사람들을 데려가서 뭘 하려는지 제가 어떻게 믿죠?", "Gerda"));
        dialog22.Add(new DialogData("/emote:Angry//speed:down/.../speed:init/", "SnowPrince"));
        dialog22.Add(new DialogData("/emote:Angry/당돌한 아이네. 카이 못지않은.", "SnowPrince"));
        var dialogData = new DialogData("/emote:Magic/그럼 이렇게 하자. 네게 간단한 마법을 쓸 수 있도록 해줄게.", "SnowPrince");
        dialogData.Callback = () => effect();
        dialog22.Add(dialogData);
        DialogManager.Show(dialog22);
    }
    void effect()
    {
        Effect.SetActive(true);
        Destroy(Effect, 5f);
        Invoke("Talk1", 1.5f);
    }

    void Talk1()
    {
        timeline.SetActive(true);
        var dialog23 = new List<DialogData>();
        dialog23.Add(new DialogData("저 앞부터는 몬스터가 출몰하는 지역이야.", "SnowPrince"));
        dialog23.Add(new DialogData("만약 네가 슬라임을 3마리 정도 잡을 수 있다면, 데려가주는 걸로.", "SnowPrince"));
        dialog23.Add(new DialogData("/emote:Hum/한 입으로 두 말하기 없기에요?", "Gerda"));
        dialog23.Add(new DialogData("/emote:Smile/날 뭘로보고.", "SnowPrince"));
        var dialogData1 = new DialogData("좋아요! 금방 잡고 돌아오죠.", "Gerda");
        dialogData1.Callback = () => cam();
        dialog23.Add(dialogData1);
        DialogManager.Show(dialog23);
    }

    void cam()
    {
        timeline.SetActive(false);
        quest.QuestNum++;
    }
}
