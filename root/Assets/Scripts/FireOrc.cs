using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrc : Enemy {

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
            //animator.SetTrigger("Attack");
            target.TakeDamage(attackPower);
            Debug.Log(target.hp);
        }
    }

   




}
