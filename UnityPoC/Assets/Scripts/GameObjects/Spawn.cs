using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public static int numEnemiesDestroyed = 0;//number of enemies destroyed
    public static int numEnemiesSpawned = 0;//number of of enemies spawned
    public static int maxEnemies = 5; //max number enemies per level => increase w/ level

    [SerializeField]
    private bool isPickup;

    //prefabs to be spawned
    public List<GameObject> prefabs;

    private float nextSpawn = 0f; //time til next spawn
    public float spawnRate; //num sec between spawn
    public float minSpawnRate; //min num sec between spawns
    public float decSpawnFrac; //frac by which to decrease spawn interval
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

        Vector2 pos;
        if (Time.time >= nextSpawn) //If ready to spawn
        {
            // Defines the min and max ranges for x and y
            pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            // y-axis is fixed for pickups
            if (isPickup)
            {
                pos = new Vector2(Random.Range(xMin, xMax), -3f);

            }

            // Creates the random object at the random position
             Instantiate(prefabs[Random.Range(0, prefabs.Count)]).transform.position = pos;
            nextSpawn += spawnRate; //Set next spawn time

            // only applies to enemies
            if(!isPickup)
            {
                numEnemiesSpawned++;
            }
                
        }

    }

    public void DecreaseSpawnInterval()
    {
        //only applies to enemies
        if (isPickup) return;


        if (spawnRate > minSpawnRate) //Change spawn rate to fraction of what it was
            spawnRate *= decSpawnFrac;
        else //Make sure spawn rate stays above minimum
            spawnRate = minSpawnRate;
        maxEnemies += 5; //add 5 additional enemies per level
    }

    public void Update()
    {
        SpawnEnemy();
    }

}
