using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController), typeof(Camera))]
public class Player : Character
{
    Camera viewCamera;
    PlayerController controller;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
      
        Move();
        Animate();
        CameraFollow();

        if (Input.GetKeyDown(KeyCode.Mouse0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("CloseRangedAttack"))
        {
            LongRangedAttack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CloseRangedAttack();
        }
      
    }

    public void CameraFollow()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            controller.LookAt(point);
        }
    }

    public override void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CloseRangedAttack"))
        {
            moveVelocity = Vector3.zero;
        }
        controller.Move(moveVelocity);
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
}
