using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public enum Type {Spike, Arrow, Platform, Bounce, Wall};
    public Type type;
    public Vector3 dir;
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
        else if (gameObject.name.Contains("wall"))
        {
            type = Type.Wall;
        }
    }

    public void activate()
    {
        Debug.Log("activate");
        isActivated = true;
        gameObject.SetActive(true);

        switch (type) {
            case Type.Spike:
                Debug.Log("I am a spike");
                break;
            case Type.Arrow:
                Debug.Log("I am a arrow");
                break;
            case Type.Platform:
                Debug.Log("I am a platform");
                StartCoroutine(locationTransition(transform.position, transform.position + dir));
                break;
        }
        
    }

    public void deactivate()
    {
        //transform.position = initPos;
        isActivated = false;
        //Debug.Log("Deactivate");

        switch (type) {
            case Type.Spike:
                //Debug.Log("Reset spike");
                gameObject.SetActive(false);
                break;
            case Type.Arrow:
                //Debug.Log("Reset arrow");
                gameObject.transform.position = initPos;
                gameObject.SetActive(false);
                break;
            case Type.Platform:
                //Debug.Log("Reset platform");
                gameObject.transform.position = new Vector3(2.06f,3.8f,0); //stopgap measure
                gameObject.SetActive(true);
                break;
        }
        
    }

    private void Update()
    {
        if (isActivated)
        {
            switch (type)
            {
                case Type.Spike:
                    // Move the object upward in world space 1 unit/second.
                    //transform.Translate(1 * Vector3.up * Time.deltaTime, Space.World);
                    break;
                case Type.Arrow:
                    transform.Translate(1 * dir * Time.deltaTime, Space.World);
                    break;
                case Type.Platform:
                    break;
            }
        }
    }

    IEnumerator locationTransition(Vector3 startPosition, Vector3 endPosition)
    {
        float currentAnimationTime = 0.0f;
        float totalAnimationTime = 2f;
        while (currentAnimationTime < totalAnimationTime)
        {
            currentAnimationTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, currentAnimationTime / totalAnimationTime);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
