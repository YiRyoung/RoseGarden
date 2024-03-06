using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPitch : MonoBehaviour
{
    public Player player;
    public AudioSource Beep;

    void Start()
    {
        Beep = GetComponent<AudioSource>();
    }

    void Update()
    {
        float d = Vector2.Distance(this.transform.position, player.transform.position);
        Mathf.Abs(d);
        if (d <= 1)
        {
            Beep.spatialBlend = 0;
        }
        else if (1 < d && d <= 3)
        {
            Beep.spatialBlend = 0.25f;
        }
        else if (3 < d && d <= 5)
        {
            Beep.spatialBlend = 0.5f;
        }
        else if (5 < d && d <= 7)
        {
            Beep.spatialBlend = 0.75f;
        }
        else
        {
            Beep.spatialBlend = 1f;
        }

    }
}
