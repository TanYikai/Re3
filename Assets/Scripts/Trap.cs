using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public enum Type {Spike, Arrow, Platform, Bounce};
    public Type type;
    private Vector3 initPos;
    private bool isActivated;

    public void initTrap()
    {
        initPos = gameObject.transform.position;
        isActivated = false;

        if (gameObject.name.Contains("spike"))
        {
            type = Type.Spike;
        }
        else if (gameObject.name.Contains("arrow"))
        {
            type = Type.Arrow;
        }
        else if (gameObject.name.Contains("platform"))
        {
            type = Type.Platform;
        }
        else if (gameObject.name.Contains("bounce"))
        {
            type = Type.Bounce;
        }
    }

    public void activate()
    {
        Debug.Log("activate");
        isActivated = true;
    }

    public void deactivate()
    {
        transform.position = initPos;
        isActivated = false;
    }

    private void Update()
    {
        if (isActivated)
        {
            switch (type)
            {
                case Type.Spike:
                    Debug.Log("I am a spike");
                    // Move the object upward in world space 1 unit/second.
                    transform.Translate(1 * Vector3.up * Time.deltaTime, Space.World);
                    break;
                case Type.Arrow:
                    break;
                case Type.Platform:
                    break;
            }
        }
    }
    

}
