using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOnClick : MonoBehaviour {
    Animator animazione;
    
    // Use this for initialization
    void Start () {
        animazione = gameObject.GetComponent<Animator>();
    }
	
	void FixedUpdate () {
        //lo so che non è fisica 
        if (Input.GetMouseButtonDown(0)) //0 Tasto sinistro
        {
            
            //animazione.Play("Wizard_Skill");
           
            animazione.SetTrigger("Active");

        }
    }
}
