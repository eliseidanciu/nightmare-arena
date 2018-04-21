using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : Character
{ 
    protected NavMeshAgent pathfinder;
    protected Transform target;

    private void Awake()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        pathfinder.speed = moveSpeed;

        
    }

    protected void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
	}

    protected void Update()
    {
        transform.LookAt(target);
    }
    

    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
