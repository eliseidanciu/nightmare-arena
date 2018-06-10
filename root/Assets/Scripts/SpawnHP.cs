using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHP : MonoBehaviour
{

    public GameObject HPPrefab;

    public Transform spawnPoint1;
    public Transform spawnPoint2;

    private float delay = 100f;
    private float firstDelay = 20f;

    void Start()
    {
        InvokeRepeating("SpawnLife", firstDelay, delay);
    }

    void Update()
    {

    }

    public void SpawnLife()
    {

        var hp1 = Instantiate(HPPrefab);
        var hp2 = Instantiate(HPPrefab);

        //PROGRAMMING 101
        hp1.transform.position = spawnPoint1.transform.position;
        hp1.transform.Translate(0f, 3f, 0f);
        hp2.transform.position = spawnPoint2.transform.position;
        hp2.transform.Translate(0f, 3f, 0f);
    }
    

    
}

