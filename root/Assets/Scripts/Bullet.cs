using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    public float speed;
    public float lifeTime;
    public GameObject hitParticles;
    public Character attacker;

    Rigidbody rb;
    AudioSource soundImpact;
    bool isDestroyed;

	void Start () {
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody>();
        soundImpact = GetComponent<AudioSource>();
        isDestroyed = false;
	}
	
	void FixedUpdate () {
        if(!isDestroyed)
            rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (attacker != null && other != null)
        {
            //Ignore collision with enemies if the attacker was also an enemy or the bullets collides with another bullet
            if (!(other.CompareTag("Enemy") && attacker.CompareTag("Enemy")) && !(other.CompareTag("Bullet")))
            {
                Instantiate(hitParticles, transform.position, transform.rotation);
                rb.velocity = Vector3.zero;
                isDestroyed = true;
                Destroy(gameObject, 0.3f);
            }

            //Cause damage to the target making sure to ignore friendly fire
            if ((attacker.CompareTag("Enemy") && other.CompareTag("Player")) || (attacker.CompareTag("Player") && other.CompareTag("Enemy")))
            {
                soundImpact.Play();
                var enemy = other.gameObject.GetComponent<Character>();
                enemy.TakeDamage(attacker.attackPower);
            }

            
        }
    }
}
