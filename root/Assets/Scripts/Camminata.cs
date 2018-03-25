using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camminata : MonoBehaviour {
    Animator animazione;

    // Use this for initialization
    void Start()
    {
        animazione = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //lo so che non è fisica 
      
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) //0 Tasto sinistro
        {
            //animazione.Play("Wizard_Skill");

            animazione.SetTrigger("Walk");

        }
        else
        {
            animazione.SetTrigger("ExitWalk");

        }
    }
}
