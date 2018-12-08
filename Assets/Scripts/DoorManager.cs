using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

    private void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,0, Time.deltaTime * 50));

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && GameManager.hasPickedUp == true)
        {
            // new level
            GameManager.restartLevel(true);
        }
    }
}
