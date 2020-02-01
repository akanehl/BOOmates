using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostController : MonoBehaviour
{
    static int numplayers = 0;
    int playernum;
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

    public bool gramSwitch = false;
    GameObject gramophone;
    GramophoneScript musicPlayer;
    GameObject worldMusic;
    static bool playing;

    public Material color1;
    public Material color2;
    public MeshRenderer mesh;
    private float invisVal;
    private bool dissapearing;

    private void Awake()
    {
        player = new Controller();

        lighting = GameObject.FindGameObjectWithTag("Lights");
        worldLighting = GameObject.FindGameObjectWithTag("EnvironmentLights");
        lights = lighting.GetComponent<LightScript>();

        gramophone = GameObject.FindGameObjectWithTag("Gramophone");
        worldMusic = GameObject.FindGameObjectWithTag("WorldMusic");
        musicPlayer = gramophone.GetComponent<GramophoneScript>();
        playing = false;

        invisVal = 0;
        dissapearing = false;

        playernum = numplayers;
        numplayers++;

        if(playernum == 0)
        {
            mesh.material = color1;
        }
        if (playernum == 1)
        {
            mesh.material = color2;
        }



    }

    private void FixedUpdate()
    {
        //Update Variables
        if (playernum == 0)
        {
            lightSwitch = lights.locked1;
            gramSwitch = musicPlayer.locked1;
        }
        if (playernum == 1)
        {
            lightSwitch = lights.locked2;
            gramSwitch = musicPlayer.locked2;
        }
      

        //First, we calculate movement speed+direction
        calculateMovement();
        //Secondly, calculate invisibility
        calculateInvisibility();

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
    void calculateInvisibility()
    {
        Debug.Log(dissapearing);

        if(dissapearing)
        {
            if(invisVal <300)
            {
                invisVal++;
            }
        }
        else
        {
            if(invisVal>0)
            {
                invisVal--;
            }
        }

        if(playernum == 0)
        {
            color1.SetFloat("Vector1_33017E18", invisVal);
        }
        else
        {
            color2.SetFloat("Vector1_DB39D30F", invisVal);
        }
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
    void OnMusic()
    {
        
        AudioSource spookyClip = worldMusic.GetComponent<AudioSource>();

        if (!gramSwitch)
        {
            if(playing == false)
            {
                spookyClip.Play();
                playing = true;
            }
            else
            {
                spookyClip.Pause();
                playing = false;
            }
            
                
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

    private void OnInvis()
    {
        
        dissapearing = true;
    }
    private void OnAppear()
    {
        
        dissapearing = false;
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
