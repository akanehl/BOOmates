using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostController : MonoBehaviour
{
    Controller player;
    Vector2 moveVec;

    public Rigidbody rigBod;
    public double moveSpeed;
    private double baseSpeed = 400;

    public bool powerUp;
    public float punchForce = 0;
    public float maxPunchForce;

    public bool lightSwitch = false;
    GameObject lighting;
    LightScript lights;
    GameObject worldLighting;

    private void Awake()
    {
        player = new Controller();
        lighting = GameObject.FindGameObjectWithTag("Lights");
        worldLighting = GameObject.FindGameObjectWithTag("EnvironmentLights");
        lights = lighting.GetComponent<LightScript>();

    }

    private void FixedUpdate()
    {
        
        //Update Variables
        lightSwitch = lights.locked;
        Debug.Log(lightSwitch);

        //First, we calculate movement speed+direction
        calculateMovement();

        //Then, Dash Calculations
        doPunch();
    }
    void calculateMovement()
    {
        Vector3 movement;
        //Movement modifications for PoweringUp
        if (powerUp)
        {
            movement = new Vector3(-moveVec.x, 0.0f, -moveVec.y);
        }
        else
        {
            movement = new Vector3(moveVec.x, 0.0f, moveVec.y);
        }

        rigBod.AddForce(movement * (float)moveSpeed);
    }

    void doPunch()
    {
        //Player is holding down punch button
        if (powerUp)
        {
            //Movement modifications here
            if (punchForce < maxPunchForce)
            {
                punchForce++; //PunchForce charges up over 50 frames
                if (moveSpeed >= 10)
                {
                    moveSpeed -= 10;
                }

            }
        }
        else
        {
            rigBod.AddForce(moveVec.x * punchForce * 1000, 0.0f, moveVec.y * punchForce * 1000);
            if (moveSpeed < baseSpeed)
            {
                moveSpeed += 5;
            }

            punchForce = 0;
        }
    }
    void OnLights()
    {
       
        if (!lightSwitch)
        {
            worldLighting.SetActive(!(worldLighting.activeSelf));
        }
    }
    void OnPunch()
    {
        //Button is held down
        powerUp = true;
        
    }
    void OnLaunch()
    {
        //Button is rleased;
        powerUp = false;
    }
    private void OnMovement(InputValue value)
    {
        //update direction of movement
        moveVec = value.Get<Vector2>();
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
