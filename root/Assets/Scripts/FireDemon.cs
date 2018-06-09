using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDemon : Enemy {

    public AudioSource fireBallSound;


    void Start()
    {
        base.Start();
        attackDistance = 30f;
    }

    void Update()
    {
        if (isAlive && target.isAlive)
        {
            base.Update();
            Attack();
            if(target)
            {
                transform.LookAt(target.transform);
            }
        }
    }

    public override void Attack()
    {
        if (distanceFromTarget < attackDistance && Time.time > nextAttackTime)
        {
            float msBetweenAttacks = 60 / attackSpeed * 1000;
            nextAttackTime = Time.time + (msBetweenAttacks / 1000);
            animator.SetTrigger("Attack");
            animator.ResetTrigger("Move");
            fireBallSound.Play();
            Invoke("SpawnBullet", .4f);
        }
        else if (distanceFromTarget < attackDistance && Time.time < nextAttackTime)
        {
            animator.SetTrigger("Idle");
            pathfinder.speed = 0;
        }
        else if (distanceFromTarget > attackDistance)
        {
            animator.SetTrigger("Move");
            pathfinder.speed = moveSpeed;
        }
    }

    

    
}
