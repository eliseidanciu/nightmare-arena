using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float hp;
    public float armor;
    public float attackPower;
    public float attackSpeed; //hits per minute
    public float moveSpeed;
    public bool isAlive;

    protected float msBetweenAttacks;
    protected float nextAttackTime;

    protected Animator animator;
    protected GameObject deathParticles;
    protected Transform target;

    public Character()
    {
        hp = 100f;
        armor = 0f;
        attackPower = 10f;
        attackSpeed = 60f;
        moveSpeed = 10f;
        isAlive = true;
        msBetweenAttacks = 60 / attackSpeed * 1000;
    }

    public Character(float _hp, float _armor, float _attackPower, float _attackSpeed, float _moveSpeed, bool _isAlive)
    {
        PropertyValidation(0f, 100f, out hp, _hp);
        PropertyValidation(0f, 100f, out armor, _armor);
        PropertyValidation(0f, 100f, out attackPower, _attackPower);
        PropertyValidation(30f, 100f, out attackSpeed, _attackSpeed);
        PropertyValidation(3f, 20f, out moveSpeed, _moveSpeed);
        isAlive = _isAlive;
        msBetweenAttacks = (60 / attackSpeed) * 1000;
    }

    public virtual void TakeDamage(float enemyAttackPower)
    {
        animator.Play("TakeDamage");
        float damage = enemyAttackPower / 100 * armor;
        hp = hp - damage;
        if(hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        animator.Play("Die");
        isAlive = false;
            Destroy(gameObject);
            Instantiate(deathParticles, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(deathParticles, 1f);
        
    }

    public virtual void CloseRangedAttack(/*IDamageable enemy*/)
    {
        if (Time.time > nextAttackTime)
        {
            nextAttackTime = Time.time + (msBetweenAttacks / 1000);
            animator.SetTrigger("CloseRangedAttack");
            Debug.Log("Attack Animation");
            
            // enemy.TakeDamage(attackPower);
            
        }
    }

    public abstract void Move();

    /*
    public virtual void LongRangedAttack(Character enemy)
    {
        if (Time.time > nextAttackTime)
        {
            animation.Play("LongRangedAttack");
            if (animation.IsPlaying("LongRangedAttack"))
            {
                Projectile newProjectile = Instantiate(Projectile, )
            }
        }

    }*/

    private void PropertyValidation(float minValue, float maxValue, out float value, float desiredValue)
    {
        if (desiredValue > maxValue)
        {
            value = maxValue;
        }
        else if (desiredValue < minValue)
        {
            value = minValue;
        }
        else
        {
            value = desiredValue;
        }
    }
}
