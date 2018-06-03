using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator), typeof(Rigidbody))]
public abstract class Character : MonoBehaviour
{
    public float hp;
    public float armor;
    public float attackPower;
    public float attackSpeed; //hits per minute
    public float moveSpeed;
    public bool isAlive;

    public Bullet bulletPrefab;
    public Transform bulletSpawn;
    public GameObject deathParticles;

    protected float nextAttackTime;
    protected Rigidbody rb;
    protected Animator animator;
    protected CapsuleCollider bodyCollider;


    public abstract void Move();
    public abstract void Attack();

    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider>();
    }

    public virtual void TakeDamage(float enemyAttackPower)
    {
        float damage = enemyAttackPower / armor * 10;
        hp -= damage;
        Debug.Log(hp + "hp");
        if(hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        isAlive = false;
        animator.SetTrigger("Die");
        moveSpeed = 0;
        Destroy(gameObject, 3f);
        Destroy(bodyCollider);
        //Instantiate(deathParticles, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(deathParticles, 1f);
        
    }


}
