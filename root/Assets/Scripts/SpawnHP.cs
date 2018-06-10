using System.Collections;
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

    }

    public void SpawnLife()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),2, Random.Range(-size.z / 2, size.z / 2));

        Instantiate(HPPrefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
