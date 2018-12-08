using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool debug;
    public static bool hasPickedUp;
    public static int level;

    private static GameObject player;
    private static GameObject key;
    private static Vector3 playerInitPos;
    private static GameManager Instance;
    private static GameObject timerText;
    private static GameObject fadeScreen;
    private static GameObject sfxManager;
    private static List<Trap> traps;
    private static List<Trigger> trapTriggers;
    private static GameObject[] trapGameObjects;
    private static GameObject[] trapTriggerGameObjects;
    private static GameObject[] disappearPlatforms;

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
        key = GameObject.Find("key");
        key.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Part " + (level + 1));
        playerInitPos = player.transform.position;
        timerText = GameObject.Find("TimerText");
        fadeScreen = GameObject.Find("FadeScreen");
        sfxManager = GameObject.Find("SfxManager");
        disappearPlatforms = GameObject.FindGameObjectsWithTag("Disappear");
        //traps = FindObjectsOfType(typeof(Trap)) as Trap[];
        trapGameObjects = GameObject.FindGameObjectsWithTag("Trap");
        trapTriggerGameObjects = GameObject.FindGameObjectsWithTag("Trigger");
        trapTriggers = new List<Trigger>();
        traps = new List<Trap>();
        Debug.Log(trapGameObjects.Length);
        foreach (GameObject trapGameObject in trapGameObjects) {
            traps.Add(trapGameObject.GetComponent<Trap>());
        }

        foreach (Trap trap in traps)
        {
            trap.initTrap();
        }

        resetTraps();
        setUpLevel();
        //SfxManager.PlaySound("backgroundMusic");
        //sfxManager.GetComponent<SfxManager>().PlaySound("backgroundMusic");
    }



    private static void setUpLevel()
    {
        Debug.Log("Level " + level);
        if (level >= 12) {
            SfxManager.PlaySound("endGame");
            Debug.Log("End");
            fadeScreen.GetComponent<Fade>().FadeOut();

        } else {
            foreach (GameObject trigger in trapTriggerGameObjects) {
                if (level >= trigger.GetComponent<Trigger>().trapLevel) {
                    trigger.GetComponent<Trigger>().isEnabled = true;
                } else {
                    trigger.GetComponent<Trigger>().isEnabled = false;
                }
            }
        }
    }

    public static void restartLevel(bool hasCompletedLevel)
    {
        hasPickedUp = false;
        if (hasCompletedLevel)
        {
            level++;
        }
        key.GetComponent<SpriteRenderer>().enabled = true;
        key.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Part " + (level + 1));
        player.GetComponent<Transform>().position = playerInitPos;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        resetTraps();
        timerText.GetComponent<Timer>().stopTimer(hasCompletedLevel);
        fadeScreen.GetComponent<Fade>().FadeIn();
        setUpLevel();
    }

    public static void resetTraps()
    {
        foreach (Trap trap in traps)
        {
            trap.deactivate();
        }

        foreach (GameObject platform in disappearPlatforms)
        {
            platform.SetActive(true);
        }
        
    }

    public static void pickUp()
    {
        key.GetComponent<SpriteRenderer>().enabled = false;
        hasPickedUp = true;
    }

    public static void startTimerCountdown()
    {
        timerText.GetComponent<Timer>().startTimer();
    }

    public static GameManager getInstance()
    {
        return Instance;
    }

}