using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public Transform[] spawnPoints;
    public Enemy[] enemies;

    float spawnDelay;
    float timeSinceLastSpawn;

    float timeBetweenDifficultyIncrements;
    float timeSinceLastDifficultyIncrement;
    float difficultyMultiplier;

    void Start()
    {
        spawnDelay = 5.0f;
        difficultyMultiplier = 1.1f;
        timeSinceLastSpawn = 0.0f;
        timeBetweenDifficultyIncrements = 10.0f;
        timeSinceLastDifficultyIncrement = 0.0f;
    }
    

    void Update()
    {
        SpawnMonsters();
        IncreaseDifficulty();
    }

    void IncreaseDifficulty()
    {
        timeSinceLastDifficultyIncrement += Time.deltaTime;
        if (timeSinceLastDifficultyIncrement >= timeBetweenDifficultyIncrements && spawnDelay >= 1.0f)
        {
            spawnDelay /= difficultyMultiplier;
            timeSinceLastDifficultyIncrement = 0.0f;
        }
    }

    void SpawnMonsters()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (spawnDelay <= timeSinceLastSpawn)
        {
            timeSinceLastSpawn = 0.0f;
            

            var enemy = Instantiate(enemies[GetRandomInteger()]);
            enemy.transform.position = spawnPoints[GetRandomInteger()].position;


        }
    }
    
    int GetRandomInteger()
    {
        float indexFloat = Random.Range(0f, 1f);
        int index = 0;
        if (indexFloat > 0.5f)
            index = 1;

        return index;
    }

}
