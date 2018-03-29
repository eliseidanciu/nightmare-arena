using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float speed;
    float lifeTime;
    public Character attacker;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        speed = 50;
        lifeTime = 3f;
        Destroy(gameObject, lifeTime);
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            var enemy = other.gameObject.GetComponent<Character>();
            enemy.TakeDamage(attacker.attackPower);
        }
    }
}
