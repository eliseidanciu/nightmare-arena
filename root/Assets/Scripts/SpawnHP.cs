<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHP : MonoBehaviour {

    public GameObject HPPrefab;

    public Vector3 center;
    public Vector3 size;

    public Character oggetto;
    private float vita;
    private object objectWithOtherScript;

    void Start () {
        InvokeRepeating("SpawnLife", 2, 2.5f);
    }
	
	void Update () {

        vita = oggetto.hp;


        //objectWithOtherScript.GetComponent.<>().someVariable =;




        /*

                if(vita<=50)
                    {
                    SpawnLife();
                }

            */
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHP : MonoBehaviour
{

    public GameObject HPPrefab;

    public Transform spawnPoint1;
    public Transform spawnPoint2;

    Character oggetto;
    private float vita;
    private float delay = 100f;
    private float firstDelay = 20f;
    private object objectWithOtherScript;

    void Start()
    {
        InvokeRepeating("SpawnLife", firstDelay, delay);
        oggetto = FindObjectOfType<Player>() as Player;
    }

    void Update()
    {
>>>>>>> 1bf610992c24c1fc390cd2765644acbaecaa0345

    }

    public void SpawnLife()
    {
<<<<<<< HEAD
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),2, Random.Range(-size.z / 2, size.z / 2));

        Instantiate(HPPrefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
=======

        var hp1 = Instantiate(HPPrefab);
        var hp2 = Instantiate(HPPrefab);

        //PROGRAMMING 101
        hp1.transform.position = spawnPoint1.transform.position;
        hp1.transform.Translate(0f, 3f, 0f);
        hp2.transform.position = spawnPoint2.transform.position;
        hp2.transform.Translate(0f, 3f, 0f);
    }
    

    
}

>>>>>>> 1bf610992c24c1fc390cd2765644acbaecaa0345
