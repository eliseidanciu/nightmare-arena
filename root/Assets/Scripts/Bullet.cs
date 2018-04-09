using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    float speed;
    float lifeTime;
    public Character attacker;
    Rigidbody rb;

	void Start () {
        speed = 50;
        lifeTime = 3f;
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if((CompareTag("Enemy") && other.CompareTag("Player")) || (CompareTag("Player") && other.CompareTag("Enemy")))
        {
            var enemy = other.gameObject.GetComponent<Character>();
            enemy.TakeDamage(attacker.attackPower);
        }
    }
}
