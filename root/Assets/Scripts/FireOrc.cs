using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrc : Enemy
{

    void Start()
    {
        base.Start();
        attackDistance = 7f;
    }

    void Update()
    {
        base.Update();
        Attack();
    }

    public override void Attack()
    {
        if (distanceFromTarget < attackDistance && Time.time > nextAttackTime)
        {
            float msBetweenAttacks = 60 / attackSpeed * 1000;
            nextAttackTime = Time.time + (msBetweenAttacks / 1000);
            animator.SetTrigger("Attack");
            animator.ResetTrigger("Move");
            target.TakeDamage(attackPower);
            pathfinder.speed = 0;
            transform.LookAt(target.transform);
            
        }
        else if(distanceFromTarget < attackDistance && Time.time < nextAttackTime)
        {
            animator.SetTrigger("Idle");
            pathfinder.speed = 0;
        }
        else if(distanceFromTarget > attackDistance)
        {
            animator.SetTrigger("Move");
            pathfinder.speed = moveSpeed;
        }
    }






}
