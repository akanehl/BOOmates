using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestControllMovement : MonoBehaviour
{
    Controller player;
    Vector2 moveVec;

    public Rigidbody rigBod;
    public double moveSpeed;
    private double baseSpeed = 400;

    public bool powerUp;
    public float punchForce = 0;
    public float maxPunchForce;

    private void Awake()
    {
        player = new Controller();

        player.Gameplay.Punch.started += context => BeginPunch();
        player.Gameplay.Punch.canceled += context => EndPunch();

        player.Gameplay.Movement.performed += context => moveVec = context.ReadValue<Vector2>();
        player.Gameplay.Movement.canceled += context => moveVec = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector3 movement;

        if (powerUp)
        {
            movement = new Vector3(-moveVec.x, 0.0f, -moveVec.y);
        }
        else
        {
            movement = new Vector3(moveVec.x, 0.0f, moveVec.y);
        }
        
        rigBod.AddForce(movement * (float)moveSpeed);


        //Player is holding down punch button
        if(powerUp)
        {
            //Movement modifications here
            if ( punchForce < maxPunchForce)
            {
                punchForce++; //PunchForce charges up over 50 frames
                if(moveSpeed >= 10)
                {
                    moveSpeed -= 10;
                }
                
            }
        }
        else
        {
            rigBod.AddForce(moveVec.x * punchForce * 1000, 0.0f, moveVec.y * punchForce * 1000);
            if(moveSpeed < baseSpeed)
            {
                moveSpeed += 5;
            }
           
            punchForce = 0;
        }
    }

    void BeginPunch()
    {
        powerUp = true;
    }
    void EndPunch()
    {
        powerUp = false;
    }

    void Move()
    {
        Debug.Log("Is moving");
        
    }
    
    void OnEnable()
    {
        player.Gameplay.Enable();
    }

    private void OnDisable()
    {
        player.Gameplay.Disable();
    }
}
