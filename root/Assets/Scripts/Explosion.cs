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
        lifeTime = 1.8f;
        damageMultiplier = 5;
        var explosion = Instantiate(particles, transform.position, transform.rotation);
        Destroy(explosion, lifeTime);
        
	}
	

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<Character>();
            enemy.TakeDamage(attacker.attackPower * damageMultiplier);
            Debug.Log(enemy.hp);
        }
        Destroy(gameObject);

    }
}
