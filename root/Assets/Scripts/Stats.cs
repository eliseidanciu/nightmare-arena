using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour //Character 
{
    Character oggetto;
    public float riempimento;


    [SerializeField]

    public Image vita;
      

	void Start () {
        oggetto = FindObjectOfType<Player>();
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
