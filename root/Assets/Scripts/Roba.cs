using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roba : MonoBehaviour
{
    public GameObject Prefab;

    public Transform spawnPoint2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }

    public void Test()
    {
        var mostro = Instantiate(Prefab);

        //PROGRAMMING 101
        mostro.transform.position = spawnPoint2.transform.position;
    }
}
