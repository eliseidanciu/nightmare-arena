using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    public float speed;
    public float lifeTime;

    public Character attacker;
    Rigidbody rb;

	void Start () {
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(attacker != null && other != null)
        {

            //Ignore collision with enemies if the attacker was also an enemy or the bullets collides with another bullet
            if (!(other.CompareTag("Enemy") && attacker.CompareTag("Enemy")) && !(other.CompareTag("Bullet")))
            {
                Destroy(gameObject);
            }

            //Cause damage to the target making sure to ignore friendly fire
            if ((attacker.CompareTag("Enemy") && other.CompareTag("Player")) || (attacker.CompareTag("Player") && other.CompareTag("Enemy")))
            {
                var enemy = other.gameObject.GetComponent<Character>();
                enemy.TakeDamage(attacker.attackPower);
                Debug.Log(enemy.name + ": " + enemy.hp + "left");
            }

            
        }
        

        
    }
}
