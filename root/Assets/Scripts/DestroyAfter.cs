using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {
    public float seconds;
    private float timePassed;

	void Start () {
        timePassed = 0;	
	}
	
	void Update () {
		if(timePassed > seconds)
        {
            Destroy(gameObject);
        }
        else
        {
            timePassed += Time.deltaTime;
        }
	}
}
