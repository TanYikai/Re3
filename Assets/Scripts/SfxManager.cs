using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour {
    public static AudioClip jump;
    public static AudioClip clockDeath;
    public static AudioClip arrowShooting;
    public static AudioClip backgroundMusic;
    public static AudioClip ticking;
    public static AudioClip endGame;
    public static AudioClip levelComplete;

    private static bool muteSfx;

    static AudioSource audioSrc;
    private static SfxManager instance = null;

    // Use this for initialization
    void Awake () {
        jump = Resources.Load<AudioClip>("Jump");
        clockDeath = Resources.Load<AudioClip>("Dying");
        arrowShooting = Resources.Load<AudioClip>("Arrow");
        backgroundMusic = Resources.Load<AudioClip>("BgMusic");
        ticking = Resources.Load<AudioClip>("Ticking");
        endGame = Resources.Load<AudioClip>("ClockTwelve");
        levelComplete = Resources.Load<AudioClip>("levelComplete");
        audioSrc = gameObject.GetComponent<AudioSource>();
        audioSrc.volume = 0.4f;

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
            case "ticking":
                audioSrc.PlayOneShot(ticking);
                break;
            case "levelComplete":
                audioSrc.PlayOneShot(levelComplete);
                break;
            case "endGame":
                audioSrc.PlayOneShot(endGame);
                break;
            case "stop":
                audioSrc.Stop();
                break;
        }
    }

    public AudioSource getAudioSource()
    {
        return audioSrc;
    }

}
