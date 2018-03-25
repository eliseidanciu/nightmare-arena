using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
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
        CameraFollow();
        if(Input.GetKeyDown(KeyCode.Mouse0))
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
            //Debug.DrawLine(ray.origin, point, Color.red);
            //Debug.DrawRay(ray.origin,ray.direction * 100,Color.red);
            controller.LookAt(point);
        }
    }

    public override void Move()
    {
        animator.SetTrigger("Move");
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);
    }
}
