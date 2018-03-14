using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [System.Serializable]
    public class Wave{
            public GameObject[] enemies;
            public int amount; //number of enemies to spawn at one time
            public int maxSpawned = 0; //max number of enemies that will be spawned
            public int spawnCount = 0; //current number of enemies spawned
    }

    public List<Wave> waves; //list of all wave types
    Wave chosenWave; //wave to be executed


    public float waitingForNextSpawn; //time between waves
    public float countdown; //time til next wave

    // the range of X enemies will be spawned
    public float xMin = -5.82f;
    public float xMax = 5.82f;

    // the range of y enemies will be spawned
    public float yMin = 0f;
    public float yMax = Screen.height;

    public bool isEnabled = false; //flag to enable and disable the level
    public static int totNumWaves = 3; //total number of waves in a level
    public static int waveCount = 0; //current number of waves executed

    public static int numEnemies = 0;

    void Start()
    {
    }



    public void Update()
    {
        //if disabled don't spawn
        if (!isEnabled)
            return;
        
        // timer to spawn the next wave
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            //pick random wave
            chosenWave = waves[Random.Range(0, waves.Count)];
            //spawn the wave
            SpawnEnemies(chosenWave.amount);
            //time spawn between spawn
            countdown = waitingForNextSpawn;
        }

    }

	void SpawnEnemies(int numSpawnAtOnce)
    {
        //spawn until max number of enemies reached for wave
        for (int i = 0; i < numSpawnAtOnce; i++)
        {
            if (chosenWave.spawnCount != chosenWave.maxSpawned && chosenWave.enemies.Length != 0)
            {
                //pick random enemy
                GameObject enemyPrefab = chosenWave.enemies[Random.Range(0, chosenWave.enemies.Length)];

                // Defines the min and max ranges for x and y
                Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

                // Creates the random object at the random position
                Instantiate(enemyPrefab).transform.position = pos;

                //increase spawn count
                chosenWave.spawnCount++;
                //keep track number of enemies on board
                numEnemies++;
            }
        }
        //keep track of waves
        waveCount++;
    }

}
