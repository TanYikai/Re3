using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public Animator animator;

    // Use this for initialization
    void Start () {
        Invoke("TransitBackMenu", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnFadeComplete() {
        SceneManager.LoadScene("MainMenu");
    }

    public void TransitBackMenu() {
        Debug.Log("Start");
        animator.SetTrigger("FadeOut");
    }
}
