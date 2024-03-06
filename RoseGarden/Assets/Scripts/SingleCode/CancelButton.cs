using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour
{
    public GameObject Panel;

    public void CancelPanel()
    {
        Panel.SetActive(false);
    }
}
