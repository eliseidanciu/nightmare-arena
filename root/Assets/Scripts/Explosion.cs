using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public GameObject[] particles;
    public Character attacker;

    float lifeTime;
    float damageMultiplier;

	void Start ()
    {
        lifeTime = 3f;
        damageMultiplier = 5;
        foreach (var item in particles)
        {
            var explosion = Instantiate(item, transform.position, transform.rotation);
            Destroy(explosion, lifeTime);
        }
	}
	
	void LateUpdate ()
    {
        //Destroy(gameObject);
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
