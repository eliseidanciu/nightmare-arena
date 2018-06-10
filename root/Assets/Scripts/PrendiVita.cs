using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrendiVita : MonoBehaviour {


    //  public GameObject aumentaVita;

    public GameObject[] aumenta;

    void Start () {

    }
	
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            gameObject.SetActive(false);
            Player player = other.GetComponent<Player>();

            player.hp = 100;

        }

    }
}
