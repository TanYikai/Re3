using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.GetComponent<Trap>().initTrap();
                child.gameObject.GetComponent<Trap>().activate();
            }
        }
    }
}
