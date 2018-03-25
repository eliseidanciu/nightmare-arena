using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {
    Animator animazione;

    // Use this for initialization
    void Start(){
    }

    void FixedUpdate()
    {
        //lo so che non è fisica 
        if (Input.GetMouseButtonDown(0)) //0 Tasto sinistro
        {

            transform.GetChild(0).gameObject.SetActive(true);

            

        }
      

    }
}
