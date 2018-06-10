using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gira : MonoBehaviour
{
    public float speed;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up * speed, Space.World);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vita"))
        {
            other.gameObject.SetActive(false);

        }
    }
}
