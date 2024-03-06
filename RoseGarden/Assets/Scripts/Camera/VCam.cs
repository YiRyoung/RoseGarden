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
        //Follow 변경
        vcam = GetComponent<CinemachineVirtualCamera>();
        tPlayer = null;
    }

    void Start()
    {
        // Follow 재정의
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
