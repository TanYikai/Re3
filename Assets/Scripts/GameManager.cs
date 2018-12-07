using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool debug;

    private static GameObject player;
    private static GameManager Instance;
    private static int level;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        level = 0;
        player = GameObject.Find("player");
        initLevel();
    }

    private static void initLevel()
    {
        // TODO: move player back to initial position
        player.GetComponent<Transform>().position = new Vector3(-6.0f, -2.0f, 0);

        // TODO: initialise variables needed for each level
        switch (level)
        {
            case 0:
                Debug.Log("Level 0");
                break;
            case 1:
                Debug.Log("Level 1");
                break;
            case 2:
                Debug.Log("Level 2");
                break;
            case 3:
                Debug.Log("Level 3");
                break;
            case 4:
                Debug.Log("Level 4");
                break;
            case 5:
                Debug.Log("Level 5");
                break;
            case 6:
                Debug.Log("Level 6");
                break;
            case 7:
                Debug.Log("Level 7");
                break;
            case 8:
                Debug.Log("Level 8");
                break;
            case 9:
                Debug.Log("Level 9");
                break;
            case 10:
                Debug.Log("Level 10");
                break;
            case 11:
                Debug.Log("Level 11");
                break;
            case 12:
                Debug.Log("Level 12");
                break;
            default:
                Debug.Log("Not a valid level");
                break;
        }
    }

    public static void goal()
    {
        incLevel();
        initLevel();
    }

    private static void incLevel()
    {
        level++;
    }

    public static GameManager getInstance()
    {
        return Instance;
    }

}