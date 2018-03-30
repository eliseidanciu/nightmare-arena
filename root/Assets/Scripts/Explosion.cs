using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public GameObject particles;
    public Character attacker;

    float lifeTime;
    float damageMultiplier;

	void Start ()
    {
        lifeTime = 3f;
        damageMultiplier = 5;
        Instantiate(particles, transform.position, transform.rotation);
        //Destroy(gameObject, lifeTime);
        //Destroy(particles, lifeTime);
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<Character>();
            enemy.TakeDamage(attacker.attackPower * damageMultiplier);
        }
    }
}
