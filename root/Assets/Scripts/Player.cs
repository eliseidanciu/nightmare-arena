using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



[RequireComponent(typeof(Camera))]
public class Player : Character
{
    Camera viewCamera;
    Vector3 velocity;
    AudioSource skillSound;
    AudioSource fireBallSound;
    AudioSource movementSound;

    public Explosion explosionPrefab;
    public Transform explosionSpawn;
    public CameraShake cameraShake;

    protected float nextSkillTime;

      //the last point the character was looking at before dying

    void Start()
    {
        base.Start();
        viewCamera = Camera.main;
        var soundFX = GetComponents<AudioSource>();
        skillSound = soundFX[1];
        fireBallSound = soundFX[0];
        movementSound = soundFX[2];
        
    }

    

    void Update()
    {
        if (isAlive)
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
        else
        {
            Invoke("LoadGameOver", 3f);
        }
      
    }



    public void FixedUpdate()
    {
        if(isAlive)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //This should me in LevelManager.cs but cant make it work from there.
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
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
            if (!movementSound.isPlaying)
            {
                movementSound.Play();
            }
        }
        else
        {
            animator.SetTrigger("ExitWalk");
        }
    }

    void ShakeEffect()
    {
        StartCoroutine(cameraShake.Shake(.15f, 3f));
    }


    public void SpecialAttack()
    {
        if (magic.fillAmount >= 1.0f)
        {
            magic.fillAmount = 0.0f;
            animator.SetTrigger("MeleeAttack");
            skillSound.Play();
            Invoke("ShakeEffect", .8f);
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
            fireBallSound.Play();
            Invoke("SpawnBullet", .2f);
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
