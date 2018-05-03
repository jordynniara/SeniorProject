using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransitionManager : MonoBehaviour {
    //delay between level ending and spawning
    public float lvlStartDelay = 3f;

    public GameObject lvlLabel; //text on screen showing level number
    //public List<Spawn> spawns;

    //flag on whether or not level is running
    //Note: Level can be running while spawning is not
    public static bool levelRunning;
    public static int lvlNum = 0;//current level number
	
	void Start () {
        //get the label
        lvlLabel = GameObject.Find("LevelText");

        //init level number
        lvlNum = 0;

        //level isn't running at game start
        levelRunning = false;

        //start level
        TransitionLevel();
	}
	
	// Update is called once per frame
	void Update () {
        
        //transition the level if level isn't running
        if(!levelRunning)
        {
            TransitionLevel();
        }
        if (Spawn.numEnemiesSpawned >= Spawn.maxEnemies)
        {
            //Stop spawning after so many enemies are created
            Spawn.spawnEnabled = false;

            //Stop level after all enemies are destroyed
            if (Spawn.numEnemiesSpawned == Spawn.numEnemiesDestroyed)
            {
                levelRunning = false;

                //Decrease spawn rate after every 1 levels
                if (lvlNum % 1 == 0)
                {
                    Spawn [] spawns = GetComponents<Spawn>();
                    foreach(Spawn s in spawns)
                    {
                    s.DecreaseSpawnInterval();
                    }
                }
            }
        }
	}


    public void TransitionLevel()
    {
        //disable spawning
        Spawn.spawnEnabled = false;

        //increase level number
        lvlNum++;

        //display label
        lvlLabel.GetComponent<TextMesh>().text = "LEVEL" + lvlNum;
        lvlLabel.SetActive(true);

        //set level running again
        levelRunning = true;
        //start spawning and hide label after some delay
        Invoke("HideLevelLable", lvlStartDelay);


        //reset destroyed count
        Spawn.numEnemiesDestroyed = 0;
    }

    void HideLevelLable(){
        //remove label
        lvlLabel.SetActive(false);
        //Reset spawned count
        Spawn.numEnemiesSpawned = 0;
        //start spawning
        Spawn.spawnEnabled = true;
    }
}
