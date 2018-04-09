using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour //Character 
{


    public Character oggetto;


   private float riempimento;


    [SerializeField]

    public Image vita;
      

	void Start () {

    }
	
	// Update is called once per frame
	void LateUpdate () {
        riempimento = oggetto.hp / 100;
        Barra_vita();
	}

    private void Barra_vita()
    {
        vita.fillAmount = riempimento;
    }

   
}
