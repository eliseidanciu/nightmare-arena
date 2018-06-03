using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDemon : Enemy {

    void Start()
    {
        base.Start();
        attackDistance = 30f;
    }

    void Update()
    {
        Attack();
        if (target != null)
        {
            transform.LookAt(target.transform);
        }
    }

    public override void Attack()
    {
        if (distanceFromTarget < attackDistance && Time.time > nextAttackTime)
        {
            float msBetweenAttacks = 60 / attackSpeed * 1000;
            nextAttackTime = Time.time + (msBetweenAttacks / 1000);
            animator.SetTrigger("Attack");
            var newBullet = (Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation));
            newBullet.attacker = this;
        }
    }

    
}
