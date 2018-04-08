using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrc : Enemy {

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        base.Update();
        Attack();
    }

    public override void Attack()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < 7 && Time.time > nextAttackTime)       
        {
            float msBetweenAttacks = 60 / attackSpeed * 1000;
            nextAttackTime = Time.time + (msBetweenAttacks / 1000);
            //animator.SetTrigger("Attack");
            target.TakeDamage(attackPower);
            Debug.Log(target.hp);
        }
    }

   




}
