using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour {

    Player player;

	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.Mouse2))
        {
            player.hp = 9999;
            player.armor = 9999f;
            player.attackPower = 9999f;
            player.magic.fillAmount = 9999;
        }
	}
}
