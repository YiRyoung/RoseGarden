using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    public DialogManager DialogManager; // ��ȭ �ý��� ���� ���
    public AudioSource BGM;

    void Start()
    {
        var dialog = new List<DialogData>();
        dialog.Add(new DialogData("��� ��, �ƹ��� �Ƹ��ٿ� �͵� �����ϰ� �����ִ� �ſ��� �־����ϴ�.", "Announce"));
        dialog.Add(new DialogData("�Ǹ��� �װ��� �̿��Ͽ� �Ű� õ����� ����ֱ�� �����Ծ����ϴ�.", "Announce"));
        dialog.Add(new DialogData("������ �ϴÿ� ����������� �ſ��� ���ϰ� ��鸮�� �����߽��ϴ�.", "Announce"));
        dialog.Add(new DialogData("�ᱹ /sound:BreakGlass/�Ǹ��� �ſ��� ����߸���� ���ҽ��ϴ�.", "Announce"));
        dialog.Add(new DialogData("�ſ��� ���� ���� ������� �μ��� ������� ������ �İ������ϴ�.", "Announce"));
        dialog.Add(new DialogData("�ſ� ������ ���� ������� ������ ���������� ���߽��ϴ�.", "Announce"));
        var dialogData = new DialogData("�� �̾߱�� ���ع��� ������� ���ϱ� ���� �� �ҳ��� �̾߱��Դϴ�.", "Announce");
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
