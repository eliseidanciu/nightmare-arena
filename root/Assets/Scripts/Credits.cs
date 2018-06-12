using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    private float speed;
    private float lifeTime;
    private float timePassed;

	// Use this for initialization
	void Start () {
        speed = 50f;
        lifeTime = 60f;
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
