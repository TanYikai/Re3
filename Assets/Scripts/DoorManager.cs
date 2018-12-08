using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && GameManager.hasPickedUp == true)
        {
            // new level
            GameManager.restartLevel(true);
        }
    }
}
