using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public Animator animator;
    
    public void FadeIn() {
        Debug.Log("FadeIn");
        animator.SetTrigger("FadeIn");
    }
}
