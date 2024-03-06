using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    public DialogManager DialogManager; // 대화 시스템 에셋 사용
    public AudioSource BGM;

    void Start()
    {
        var dialog = new List<DialogData>();
        dialog.Add(new DialogData("어느 날, 아무리 아름다운 것도 흉측하게 보여주는 거울이 있었습니다.", "Announce"));
        dialog.Add(new DialogData("악마는 그것을 이용하여 신과 천사들을 놀려주기로 마음먹었습니다.", "Announce"));
        dialog.Add(new DialogData("하지만 하늘에 가까워질수록 거울은 심하게 흔들리기 시작했습니다.", "Announce"));
        dialog.Add(new DialogData("결국 /sound:BreakGlass/악마는 거울을 떨어뜨리고야 말았습니다.", "Announce"));
        dialog.Add(new DialogData("거울은 수억 개의 조각들로 부서져 사람들의 심장을 파고들었습니다.", "Announce"));
        dialog.Add(new DialogData("거울 조각이 박힌 사람들은 차갑고 부정적으로 변했습니다.", "Announce"));
        var dialogData = new DialogData("이 이야기는 변해버린 사람들을 구하기 위한 한 소녀의 이야기입니다.", "Announce");
        dialogData.Callback = () => Lastlog();

        dialog.Add(dialogData);

        DialogManager.Show(dialog);
    }

    void Lastlog()
    {
        Invoke("NextScene", 0.12f);
    }
    void NextScene()
    {
        BGM.Stop();
        SceneManager.LoadScene(2);
    }
}
