using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public Animator animator;

	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FadeLevel(1);
        }

    }


    public void FadeLevel (int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }
}
