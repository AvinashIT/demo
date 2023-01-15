using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] private float walkspeed;
    [SerializeField] private float runspeed;
    [SerializeField] private float jump_height;
    private CharacterController controller;
    private Animator ani;
    private Vector3 move_direction;
    private Vector3 velocity;
    [SerializeField] private bool isgrounded;
    [SerializeField] private float ground_dis;
    [SerializeField] private LayerMask groundmask;
    [SerializeField]private float gravity;
  
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        ani = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        move();
    }
    private void move()
    {
        isgrounded = Physics.CheckSphere(transform.position,ground_dis,groundmask);
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float movez = Input.GetAxis("Vertical");
        move_direction = new Vector3(0, 0, movez);
        move_direction = transform.TransformDirection(move_direction);
        if (isgrounded)
        {
            if (move_direction != Vector3.zero && !Input.GetKeyDown(KeyCode.LeftShift))
            {
                walk();
            }
            else if ((move_direction != Vector3.zero) && (Input.GetKeyDown(KeyCode.LeftShift)))
            {
                run();
                
            }
            else if (move_direction == Vector3.zero)
            {
                idle();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                jump();
            }
        }
        
        move_direction *= movespeed;
        velocity.y += gravity *Time.deltaTime;
        controller.Move(move_direction * Time.deltaTime);
        controller.Move(velocity *Time.deltaTime);
    }
    void run()
    {
        movespeed =runspeed;
        ani.SetFloat("Speed", 1f,0.1f,Time.deltaTime);
     
    }
    void walk()
    {
        movespeed = walkspeed;
        ani.SetFloat("Speed", 0.5f,0.1f,Time.deltaTime);
    }
    void idle()
    {
        ani.SetFloat("Speed", 0,0.1f,Time.deltaTime);
    }
    void jump()
    {
        velocity.y = Mathf.Sqrt(jump_height * gravity * -2);
    }

}
