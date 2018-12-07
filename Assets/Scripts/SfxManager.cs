using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour {
    public static AudioClip jump;
    public static AudioClip clockDeath;
    public static AudioClip arrowShooting;
    public static AudioClip backgroundMusic;

    private static bool muteSfx;

    static AudioSource audioSrc;
    private static SfxManager instance = null;

    // Use this for initialization
    void Start () {
        jump = Resources.Load<AudioClip>("Jump");
        clockDeath = Resources.Load<AudioClip>("Dying");
        arrowShooting = Resources.Load<AudioClip>("Arrow");
        backgroundMusic = Resources.Load<AudioClip>("BgMusic");

        audioSrc = gameObject.GetComponent<AudioSource>();
        audioSrc.volume = 0.3f;

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "clockDeath":
                audioSrc.PlayOneShot(clockDeath);
                break;
            case "arrowShooting":
                audioSrc.PlayOneShot(arrowShooting);
                break;
            case "backgroundMusic":
                audioSrc.PlayOneShot(backgroundMusic);
                break;
        }
    }

    public AudioSource getAudioSource()
    {
        return audioSrc;
    }

}
