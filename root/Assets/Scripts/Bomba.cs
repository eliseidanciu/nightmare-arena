using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {
    Animator animazione;

    // Use this for initialization
    void Start(){
        

    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }

    void FixedUpdate()
    {
        //lo so che non è fisica 
        if (Input.GetMouseButtonDown(0)) //0 Tasto sinistro
        {
            //animazione.Play("Wizard_Attack");
            StartCoroutine(Example());
            transform.GetChild(0).gameObject.SetActive(true);

            

        }
      

    }
}
