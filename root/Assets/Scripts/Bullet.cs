using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float speed;
    float lifeTime;
    public Character attacker;

	// Use this for initialization
	void Start () {
        speed = 50;
        lifeTime = 3f;
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            var enemy = other.gameObject.GetComponent<Character>();
            enemy.TakeDamage(attacker.attackPower);
            Destroy(gameObject);
            Debug.Log(enemy.hp);
        }
    }
}
