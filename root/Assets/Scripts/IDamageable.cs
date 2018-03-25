using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float enemyAttackPower);
    void Die();
    void CloseRangedAttack(/*IDamageable target*/);
    void Move();

}
