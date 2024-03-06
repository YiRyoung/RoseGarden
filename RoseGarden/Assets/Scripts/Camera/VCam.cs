using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCam : MonoBehaviour
{
    GameObject tPlayer;
    Transform tFollowTarget;
    CinemachineVirtualCamera vcam;

    void Awake()
    {
        //Follow ����
        vcam = GetComponent<CinemachineVirtualCamera>();
        tPlayer = null;
    }

    void Start()
    {
        // Follow ������
        if (tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
            if (tPlayer != null)
            {
                tFollowTarget = tPlayer.transform;
                vcam.Follow = tFollowTarget;
            }
        }
    }
}
