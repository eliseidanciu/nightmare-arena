using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : Character
{ 
    protected NavMeshAgent pathfinder;
    protected Character target;


    private void Awake()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        pathfinder.speed = moveSpeed;
    }

    protected void Start ()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        StartCoroutine(UpdatePath());
	}

    protected void Update()
    {
        transform.LookAt(target.transform);
    }

    public override void Move()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            rb.velocity = Vector3.zero;
        }
    }

    /*
     * This function updates the enemies' path toward their target
     */
    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, 0, target.transform.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
    
}
