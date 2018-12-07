using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player" && GameManager.level == 0) {
            Debug.Log("destroy platform");
            gameObject.SetActive(false);
        }
    }
}
