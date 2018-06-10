using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    private float speed=50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        if ((Input.anyKeyDown))
        {
            Application.LoadLevel("MainMenu");
        }
    }

  
}
