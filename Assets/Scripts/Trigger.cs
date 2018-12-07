using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public int trapLevel;
    public bool isEnabled;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnabled && collision.gameObject.tag == "Player")
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(true);
                child.gameObject.GetComponent<Trap>().activate();
            }
        }
    }
}
