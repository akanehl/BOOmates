using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    
    //Add by Guanchen Liu
    //Nathan info
    GameObject Nathan;
    HumanBehavior humanScript;
    bool onHuman = false;
    private float scarePoint = 0f;
    GameObject ScareText;

    //Dash Information
    private bool powerUp;
    private float dashForce = 0;
    public float maxDashForce;

    //Light switch variables
    private bool lightBool = false;
    GameObject lightSwitch;
    LightScript lightScript;
    GameObject worldLighting;

    //Gramophone variables
    private bool gramBool = false;
    static bool musicPlaying = false;
    GameObject gramophone;
    GramophoneScript musicScript;
    GameObject worldMusic;
    
    //Painting variables
    private bool paintBool = false;
    bool hiding = false;
    GameObject painting;
    PaintingScript paintScript;

    //Material/Invisibility controls
    public Material color1;
    public Material color2;
    public MeshRenderer mesh;
    private float invisVal = 0;
    private bool dissapearing = false;

    //Add by Guanchen Liu
    //Combining human script and ghost script together
    public enum selectedItem {GrabObject, CleanObject, None}
    public selectedItem currentItem;
    public Transform _selection;
    public Transform grabItem;
    public GameObject targetPosition;

    private void Awake()
    {
        player = new Controller();

        //Assign light variables to proper objects in scene
        lightSwitch = GameObject.FindGameObjectWithTag("Lights");
        worldLighting = GameObject.FindGameObjectWithTag("EnvironmentLights");
        lightScript = lightSwitch.GetComponent<LightScript>();

        //Assign gramophone variables to proper objects in scene
        gramophone = GameObject.FindGameObjectWithTag("Gramophone");
        worldMusic = GameObject.FindGameObjectWithTag("WorldMusic");
        musicScript = gramophone.GetComponent<GramophoneScript>();

        //Assign painting variables to proper objects in scene
        painting = GameObject.FindGameObjectWithTag("Painting");
        paintScript = painting.GetComponent<PaintingScript>();

        //Assign player numbers and colors
        playernum = numplayers;
        numplayers++;

        //Add by Guanchen Liu
        //Assign nathan
        Nathan = GameObject.Find("Nathan");
        humanScript = Nathan.GetComponent<HumanBehavior>();
        currentItem = selectedItem.None;
        targetPosition = GameObject.Find("ParticleSystem");
        var canvas = GameObject.Find("Canvas").gameObject;
        ScareText = canvas.transform.Find("ScarePoints").gameObject;

        player.Gameplay.Grabbing.performed += context => OnGrabbing();
        player.Gameplay.Grabbing.canceled += context => ReleaseObject();

        if(playernum == 0)
        {
            GameObject temp = GameObject.Find("Ghost_1");
            transform.position = temp.transform.position;
            Destroy(temp);
            mesh.material = color1;
            gameObject.name = "Ghost_1";
            
        }
        if (playernum == 1)
        {
            GameObject temp = GameObject.Find("Ghost_2");
            transform.position = temp.transform.position;
            Destroy(temp);
            mesh.material = color2;
            gameObject.name = "Ghost_2";

        }
    }

    private void FixedUpdate()
    {
        //First, we calculate movement speed+direction
        calculateMovement();
        //Secondly, calculate invisibility
        calculateInvisibility();
        //Then, Dash Calculations
        doDash();
        //Update the ScarePoint Value, due to conditions
        scareManager();

        //Then, calculate the human condition tasks
        if (onHuman)
        {

            humanTask();
            onBody();

        }
        //NEEDS TO BE UPDATED TO WORK WITH MULTIPLE ITEMS
        else
        {
            if (playernum == 0)
            {
                lightBool = lightScript.locked1;
                gramBool = musicScript.locked1;
                paintBool = paintScript.locked1;
            }
            if (playernum == 1)
            {

                lightBool = lightScript.locked2;
                gramBool = musicScript.locked2;
                paintBool = paintScript.locked2;
            }
        }
    }

    void calculateMovement()
    {
        Vector3 movement;
        //Movement modifications for PoweringUp

        //Edited by Guanchen Liu

        if(!onHuman){
            if (powerUp)
            {
                movement = new Vector3(-moveVec.x, 0.0f, -moveVec.y);
            }
            else
            {
                
                movement = new Vector3(moveVec.x, 0.0f, moveVec.y);
    
            }
            rigBod.AddForce(movement * (float)moveSpeed);
        }else{
            if(currentItem != selectedItem.CleanObject)
            {
                movement = new Vector3(moveVec.x, 0.0f ,moveVec.y);
                Nathan.transform.Translate(movement * ((float)baseSpeed/2) * Time.deltaTime, Space.World);
                if(movement != Vector3.zero)
                {
                    Nathan.transform.rotation = Quaternion.LookRotation(new Vector3(moveVec.x, 0 ,moveVec.y));
                }
            }
        }
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

    void doDash()
    {
        //Player is holding down dash button
        if (powerUp)
        {
            //Movement modifications here
            if (dashForce < maxDashForce)
            {
                dashForce++; //DashForce charges up over 50 frames
                if (moveSpeed > 0)
                {
                    moveSpeed--;
                }

            }
        }
        else
        {
            rigBod.AddForce(moveVec.x * dashForce * 10, 0.0f, moveVec.y * dashForce * 10);
            if (moveSpeed < baseSpeed)
            {
                moveSpeed += 5;
            }

            dashForce = 0;
        }
    }

    //Add by Guanchen Liu
    //Test version
    //This function will decrease the scarePoint of character
    //when light is off. The ghost will eject out if the scarePoint
    //reach 0
    //Bug: The value of scarePoint and lightOn should be recorded by another script
    void scareManager()
    {
        Text t = ScareText.GetComponent<Text>();
        if(scarePoint < 100)
        {
            if (!worldLighting.activeSelf)
            {
                scarePoint += 0.05f;
            }
            if (musicPlaying)
            {
                scarePoint += 0.05f;
            }
        }

        if(scarePoint >0)
        {
            scarePoint = scarePoint -= 0.01f;
        }
        t.text = "ScarePoints: " + (int)scarePoint;
    }

    /*--------------------------------------------------------------------------------------------------------------------*/
    /* ------------------------------------GHOST INTERACTION METHODS------------------------------------------------------*/
    /*--------------------------------------------------------------------------------------------------------------------*/

    void OnLights()
    {
        //Edited BY Guanchen
        if (!lightBool)
        {
            worldLighting.SetActive(!(worldLighting.activeSelf));
        }
    }

    void OnMusic()
    {
        AudioSource spookyClip = worldMusic.GetComponent<AudioSource>();

        //Edited BY Guanchen
        if (!gramBool)
        {
            if(musicPlaying == false)
            {
                spookyClip.Play();
                musicPlaying = true;
            }
            else
            {
                spookyClip.Pause();
                musicPlaying = false;
            }       
        }
    }

    void OnHide()
    {
        //Edited BY Guanchen
        if (!paintBool)
        {

            //player isnt already hiding
            if (!hiding)
            {
                transform.position = painting.transform.GetChild(0).transform.position;
                rigBod.constraints = RigidbodyConstraints.FreezePosition;
                hiding = true;
            }
            else
            {
                rigBod.constraints = RigidbodyConstraints.None;
                rigBod.constraints = RigidbodyConstraints.FreezePositionY;
                transform.position = painting.transform.GetChild(1).transform.position;
                rigBod.AddForce((moveVec.x) * 500, 0.0f, (moveVec.y) * 500);
                hiding = false;
                Debug.Log(Vector3.Distance(transform.position, Nathan.transform.position));
                if(Vector3.Distance(transform.position, Nathan.transform.position) < 5)
                {
                    scarePoint += 75f;
                }

                //human scare point logic
            }
        }
    }

    void OnDash()
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

    /*--------------------------------------------------------------------------------------------------------------------*/
    /* ------------------------------------HUMAN INTERACTION METHODS------------------------------------------------------*/
    /*--------------------------------------------------------------------------------------------------------------------*/

    //Add by Guanchen Liu
    void OnGrabbing(){
        if(humanScript.enabled)
        {
            if(_selection != null)
            {
                if(_selection.CompareTag("GrabObject"))
                {      
                    currentItem = selectedItem.GrabObject;
                    grabItem = _selection;
                }
                else if( _selection.CompareTag("CleanObject")) 
                {
                    currentItem = selectedItem.CleanObject;
                }
            }
        }
    }

    //Edited By Guanchen Liu
    //Access by Controller
    //This function will allow ghost take over the human
    //when the human is vaccan(?)
    void OnTaking(){

        if(!onHuman && humanScript.enabled){
            var controlScript = this.GetComponent<GhostController>();
            rigBod.detectCollisions = false;
            var x = Nathan.transform.position.x;
            var y = this.transform.position.y;
            var z = Nathan.transform.position.z;
            this.transform.position = new Vector3(x,y,z);
            transform.GetChild(0).gameObject.SetActive(false);
            humanScript.enabled = false;
            
            onHuman = true;
            Nathan.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
        }
    }

    //Edited By Guanchen Liu
    //Access by Controller
    //This function will allow ghost eject from the human
    //if scarePoint equals 0, ghosts will be forced eject
    void OnLeaving(){
        if(onHuman && !humanScript.enabled){
            var rb = GetComponent<Rigidbody>();
            Vector3 randomDirection = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            rigBod.AddForce(randomDirection * (float)moveSpeed);
            
            onHuman = false;
            humanScript.enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            Nathan.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
            StartCoroutine(ExampleCoroutine());
        }

    }

    //Add by Guanchen Liu
    //Access by Controller
    //Back to title page
    void OnTitle(){
        Destroy(GameObject.Find("Ghost_1"));
        Destroy(GameObject.Find("Ghost_2"));
        numplayers = 0;
        SceneManager.LoadScene (sceneName:"MenuScreen");
    }

    //Add by Guanchen Liu
    //This function will calculate the position of ghost
    //when ghost is on human
    void onBody(){
         if(onHuman){
            var x = Nathan.transform.position.x;
            var y = this.transform.position.y;
            var z = Nathan.transform.position.z;
            this.transform.position = new Vector3(x,y,z);
         }
    }

    //Add by Guanchen Liu
    //A function to reset ghost's collision when leaving human body
    IEnumerator ExampleCoroutine(){
       yield return new WaitForSeconds(1);
       rigBod.detectCollisions = true;
    }

    //Add by Guanchen Liu
    //Origin: Enxuan
    //This function will go through the human interaction when ghosts
    //on human.
    void humanTask(){
          if(currentItem == selectedItem.GrabObject)
            {
                if(_selection != null)
                {
                    //Sound: Grab Item Sound
                    _selection.transform.position = Nathan.transform.position + Nathan.transform.forward * 1 + new Vector3(0.0f, _selection.transform.localScale.y/2, 0.0f);
                }
            }
            else if(currentItem == selectedItem.CleanObject)
            {
                if(_selection != null)
                {
                    //Sound: Clean Sound around 5 seconds
                    Nathan.transform.GetChild(0).gameObject.SetActive(true);
                    Transform timeBar = Nathan.transform.GetChild(0).GetChild(0);
                    if(timeBar.localScale.x < 1)
                    {
                        timeBar.localScale += new Vector3(Time.deltaTime * 0.2f, 0.0f, 0.0f);
                    }
                    else
                    {
                        _selection.gameObject.SetActive(false);
                        Vector3 lTemp = timeBar.localScale;
                        lTemp.x = 0.0f;
                        timeBar.localScale = lTemp;
                        Nathan.transform.GetChild(0).gameObject.SetActive(false);
                        _selection = null;
                        currentItem = selectedItem.None;
                    }
                }
            }
            else{
                Ray ray = new Ray(Nathan.transform.position, Nathan.transform.forward); 
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, 1.0f))
                {
                    if(!hit.transform.CompareTag("Human")){
                        Nathan.transform.GetChild(1).gameObject.SetActive(true);
                        if(hit.transform.CompareTag("GrabObject")){
                            Nathan.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                            Nathan.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                            _selection = hit.transform;
                        }
                        else if (hit.transform.CompareTag("CleanObject"))
                        {                        
                            Nathan.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                            Nathan.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
                            _selection = hit.transform;
                        }
                        else
                        {
                            Nathan.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                            Nathan.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
                            _selection = null;
                        }
                    }
                }
                else
                {
                    Nathan.transform.GetChild(1).gameObject.SetActive(false);
                    _selection = null;
                }
            }
    }

    //Add by Guanchen Liu
    //Origin: Enxuan
    //Access by Controller
    //This function will release the object when human is holding something
    void ReleaseObject()
    {
        // if(_selection != null){
        //     Sound: put down object Sound
        // }
        if(onHuman){
            if (currentItem == selectedItem.GrabObject)
            {
                currentItem = selectedItem.None;
                if(grabItem != null)
                {
                    Vector2 item = new Vector2(grabItem.position.x, grabItem.position.z);
                    Vector2 target = new Vector2(targetPosition.transform.position.x, targetPosition.transform.position.z);
                    if(checkItemInPos(target, item, 1)){
                        grabItem.position = new Vector3(target.x, grabItem.position.y, target.y);
                        targetPosition.gameObject.SetActive(false);
                        grabItem.tag = "PositionedItem";
                    }
                }
                grabItem = null;
            }
        }
    }

    //Add by Guanchen Liu
    //Origin: Enxuan
    //Access by Controller
    //This function will clean the dust when dust is nearby

    //Add by Guanchen Liu
    //Origin: Enxuan
    //This function will calculate the distance between player and object
    bool checkItemInPos(Vector2 target, Vector2 item, float radius)
    {
        return Vector2.Distance(target, item) < radius;
    }

}
