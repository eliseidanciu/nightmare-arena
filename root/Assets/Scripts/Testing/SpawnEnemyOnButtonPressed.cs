using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOnButtonPressed : MonoBehaviour {

    Character target;
    Vector3 pos;
    float offset;
    public FireOrc orc;
    public FireDemon demon;

	void Start () {
        offset = 20f;
        target = FindObjectOfType<Player>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z + offset);
            Instantiate(orc, pos, target.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z + offset);
            Instantiate(demon, pos, target.transform.rotation);
        }
    }
}
