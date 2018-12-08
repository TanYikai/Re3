using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGearUI : MonoBehaviour {

    private List<GameObject> gears;

	// Use this for initialization
	void Start () {
        gears = new List<GameObject>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gears.Add(gameObject.transform.GetChild(i).gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < GameManager.level; i++)
        {
                if (i % 2 == 0)
                {
                    gears[i].transform.Rotate(new Vector3(0,0, Time.deltaTime * 50) );
                }
                else
                {
                    gears[i].transform.Rotate(new Vector3(0, 0, Time.deltaTime * -50));
                }
        }

    }

}
