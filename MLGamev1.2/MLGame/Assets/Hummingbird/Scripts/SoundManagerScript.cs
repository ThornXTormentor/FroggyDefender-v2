using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip slurpSound;

    static AudioSource audioSrc;


    void Start()
    {
        slurpSound = Resources.Load<AudioClip>("SLURP");

        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "slurp":
                audioSrc.PlayOneShot(slurpSound);
                break;
        }
    }
}
