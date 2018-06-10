using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    private float speed;
    private float lifeTime;
    private float timePassed;

	// Use this for initialization
	void Start () {
        speed = 50f;
        lifeTime = 30f;
        timePassed = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        
        timePassed += Time.deltaTime;
        if(timePassed > lifeTime)
        {
            Destroy(gameObject);
        }
    }

  
}
