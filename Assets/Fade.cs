using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    public Animator animator;
    
    public void FadeIn() {
        Debug.Log("FadeIn");
        animator.SetTrigger("FadeIn");
    }

    public void FadeOut() {
        Debug.Log("FadeOut");
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene("LevelComplete");
    }

}
