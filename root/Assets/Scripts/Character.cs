using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Animator), typeof(Rigidbody))]
public abstract class Character : MonoBehaviour
{
    public float hp;
    public float armor;
    public float attackPower;
    public float attackSpeed; //hits per minute
    public float moveSpeed;
    public bool isAlive;
    const float orcMagic = 0.1f;
    const float demonMagic = 0.2f;

    public Image magic;
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

    public void SpawnBullet()
    {
        var newBullet = (Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation));
        newBullet.attacker = this;
    }

    public virtual void Die()
    {
        SyncScore();   
        isAlive = false;
        animator.SetTrigger("Die");
        moveSpeed = 0;
        Destroy(gameObject, 3f);
        Destroy(bodyCollider);
        //Instantiate(deathParticles, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(deathParticles, 1f);

    }

    public void SyncScore()
    {
        if (GetComponent<FireDemon>())
        {
            IncreaseMagicBy(demonMagic);
            ScoreManager.score += ScoreManager.DEMON_SCORE;
        }
        else if(GetComponent<FireOrc>())
        {
            IncreaseMagicBy(orcMagic);
            ScoreManager.score += ScoreManager.ORC_SCORE;
        }
    }

    public void IncreaseMagicBy(float amount)
    {
        Player player = FindObjectOfType<Player>();
        player.magic.fillAmount += amount;
    }
    


}
