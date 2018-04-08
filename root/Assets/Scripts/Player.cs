using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class Player : Character
{
    Camera viewCamera;
    Vector3 velocity;

    public Explosion explosionPrefab;
    public Transform explosionSpawn;

    protected float nextSkillTime;

    void Start()
    {
        base.Start();
        viewCamera = Camera.main;
        Move();
    }
    
    void Update()
    {

        Move();
        Animate();
        CameraFollow();

        if (Input.GetKeyDown(KeyCode.Mouse0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("CloseRangedAttack"))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpecialAttack();
        }
      
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

    }

    public override void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("MeleeAttack"))
        {
            moveVelocity = Vector3.zero;
        }
        velocity = moveVelocity;
    }

    public void CameraFollow()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            LookAt(point);
        }
    }


    public void Animate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetTrigger("Move");
        }
        else
        {
            animator.SetTrigger("ExitWalk");
        }
    }

    public void SpecialAttack()
    {
        if (Time.time > nextSkillTime)
        {
            float msBetweenAttacks = 60 / attackSpeed * 1000 * 10;
            nextSkillTime = Time.time + (msBetweenAttacks / 1000);
            animator.SetTrigger("MeleeAttack");
            Invoke("Explosion", .8f);
        }

    }

    public override void Attack()
    {
        if (Time.time > nextAttackTime)
        {
            float msBetweenAttacks = 60 / attackSpeed * 1000;
            nextAttackTime = Time.time + (msBetweenAttacks / 1000);
            animator.SetTrigger("RangedAttack");
            var newBullet = (Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation));
            newBullet.attacker = this;
        }
    }

    private void Explosion()
    {
        var explosion = Instantiate(explosionPrefab, explosionSpawn.position, explosionSpawn.rotation);
        explosion.attacker = this;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }
}
