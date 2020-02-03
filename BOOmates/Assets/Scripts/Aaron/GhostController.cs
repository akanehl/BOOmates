using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostController : MonoBehaviour
{
    //General Player Info
    static int numplayers = 0;
    int playernum;
    Controller player;
    Vector2 moveVec;
    public Rigidbody rigBod;
    private double moveSpeed;
    private double baseSpeed = 4;
    bool moved = false;

    //Dash Information
    private bool powerUp;
    private float punchForce = 0;
    public float maxPunchForce;

    //Light switch variables
    public bool lightSwitch = false;
    GameObject lighting;
    LightScript lights;
    GameObject worldLighting;

    //Gramophone variables
    public bool gramSwitch = false;
    static bool playing = false;
    GameObject gramophone;
    GramophoneScript musicPlayer;
    GameObject worldMusic;
    
    //Painting variables
    public bool paintSwitch = false;
    bool hiding = false;
    GameObject painting;
    PaintingScript paintScript;

    //Material/Invisibility controls
    public Material color1;
    public Material color2;
    public MeshRenderer mesh;
    private float invisVal = 0;
    private bool dissapearing = false;

    private void Awake()
    {
        player = new Controller();

        //Assign light variables to proper objects in scene
        lighting = GameObject.FindGameObjectWithTag("Lights");
        worldLighting = GameObject.FindGameObjectWithTag("EnvironmentLights");
        lights = lighting.GetComponent<LightScript>();

        //Assign gramophone variables to proper objects in scene
        gramophone = GameObject.FindGameObjectWithTag("Gramophone");
        worldMusic = GameObject.FindGameObjectWithTag("WorldMusic");
        musicPlayer = gramophone.GetComponent<GramophoneScript>();

        //Assign painting variables to proper objects in scene
        painting = GameObject.FindGameObjectWithTag("Painting");
        paintScript = painting.GetComponent<PaintingScript>();

        //Assign player numbers and colors
        playernum = numplayers;
        numplayers++;

       

        if(playernum == 0)
        {
            mesh.material = color1;
            gameObject.name = "Ghost_1";
            
        }
        if (playernum == 1)
        {
            mesh.material = color2;
            gameObject.name = "Ghost_2";

        }
    }

    private void FixedUpdate()
    {
        //Update Switches
        if (playernum == 0)
        {
            lightSwitch = lights.locked1;
            gramSwitch = musicPlayer.locked1;
            paintSwitch = paintScript.locked1;
        }
        if (playernum == 1)
        {

            lightSwitch = lights.locked2;
            gramSwitch = musicPlayer.locked2;
            paintSwitch = paintScript.locked2;
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
        //If player is holding button down, increase the value to a threshhold
        if(dissapearing)
        {
            //Player dissapears over 5 seconds (300 frames)
            if(invisVal <300)
            {
                invisVal++;
            }
        }
        else
        {
            //Player reappears over 5 seconds, assuming fully invisible (300 frames)
            if(invisVal>0)
            {
                invisVal--;
            }
        }

        //update the values in shader
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
                if (moveSpeed > 0)
                {
                    moveSpeed--;
                }

            }
        }
        else
        {
            rigBod.AddForce(moveVec.x * punchForce * 10, 0.0f, moveVec.y * punchForce * 10);
            if (moveSpeed < baseSpeed)
            {
                moveSpeed += 5;
            }

            punchForce = 0;
        }
    }


    /* CONTROLLER INPUT METHODS*/

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

    void OnHide()
    {
        if(!paintSwitch)
        {
            //player isnt already hiding
            if (!hiding)
            {
                transform.position = painting.transform.GetChild(0).transform.position;
                rigBod.constraints = RigidbodyConstraints.FreezePosition;
                hiding = true;
            }
            else//player is hiding
            {

                
                rigBod.constraints = RigidbodyConstraints.None;
                rigBod.constraints = RigidbodyConstraints.FreezePositionY;
                transform.position = painting.transform.GetChild(1).transform.position;
                rigBod.AddForce((moveVec.x) * 500, 0.0f, (moveVec.y) * 500);
                hiding = false;
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
