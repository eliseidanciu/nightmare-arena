using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {
    Animator ani;

	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
        ani.SetTrigger("Move");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
