using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public static int numEnemiesDestroyed = 0;//number of enemies destroyed
    public static int numEnemiesSpawned = 0;//number of of enemies spawned
    public static int lvlNum = 0;//current level number

    //prefabs to be spawned
    public List<GameObject> prefabs;

    public float nextSpawn = 0f; //time til next spawn
    public float spawnRate; //num sec between spawn
    public float minSpawnRate; //min num sec between spawns
    public static bool spawnEnabled = true; //flag to enable and disable spawning


    // the range of X enemies will be spawned
    private float xMin = -8f;
    private float xMax = 8f;

    // the range of y enemies will be spawned
    private float yMin = 0f;
    private float yMax = Screen.height;

    public void SpawnEnemy()
    {
        if (!spawnEnabled)
        {
            //keep the time set
            nextSpawn = Time.time + spawnRate;
            return;
        }
        if (Time.time >= nextSpawn) //If ready to spawn
        {
            // Defines the min and max ranges for x and y
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

            // Creates the random object at the random position
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]).transform.position = pos;
            nextSpawn += spawnRate; //Set next spawn time
            numEnemiesSpawned++;
        }

    }

    public void DecreaseSpawnInterval()
    {

        if (spawnRate > minSpawnRate) //Change spawn rate to 1/4ths what it was
            spawnRate *= 0.25f;
        else //Make sure spawn rate stays above minimum
            spawnRate = minSpawnRate;
    }

    void Start()
    {
    }



    public void Update()
    {
        SpawnEnemy();
        //Only 20 enemies per level
        if (numEnemiesSpawned >= 20)
        {
            //Stop spawning after so many enemies are created
            spawnEnabled = false;

            //Stop level after all enemies are destroyed
            if(numEnemiesSpawned == numEnemiesDestroyed)
            {
                LevelTransitionManager.levelRunning = false;
            }
                

            //Decrease spawn rate after every levels
            if (lvlNum % 3 == 0)
            {
                DecreaseSpawnInterval();
            }
        }
    }

}
