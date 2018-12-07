using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Animator animator;

    public void OnFadeComplete() {
        SceneManager.LoadScene("Level");
    }

    public void StartGame() {
        Debug.Log("Start");
        animator.SetTrigger("FadeOut");
    }
}
