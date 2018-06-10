using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour {

    public float rotationSpeed;
    public AudioSource pickupSound;

    private void Awake()
    {
        rotationSpeed = 70f;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupSound.Play();
            Player player = other.GetComponent<Player>();
            player.hp = 100;
            Destroy(gameObject, 0.2f);

        }

    }
}
