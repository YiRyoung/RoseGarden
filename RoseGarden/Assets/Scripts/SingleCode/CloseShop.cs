using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class CloseShop : MonoBehaviour
{
    public DialogManager DialogManager;
    public GameObject Panel;

    public void CancelPanel()
    {
        Panel.SetActive(false);
        Talk();
    }

    void Talk()
    {
        var dialog = new List<DialogData>();
        dialog.Add(new DialogData("/emote:Smile/������ �� ������~!", "Sandy"));
        DialogManager.Show(dialog);
    }
}
