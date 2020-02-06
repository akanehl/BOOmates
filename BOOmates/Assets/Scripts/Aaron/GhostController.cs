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
    private float scaryPoint = 100f;
    GameObject ScareText;

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

        //Add by Guanchen Liu
        //Assign nathan
        Nathan = GameObject.Find("Nathan");
        humanScript = Nathan.GetComponent<HumanBehavior>();
        currentItem = selectedItem.None;
        targetPosition = GameObject.Find("ParticleSystem");
        var canvas = GameObject.Find("Canvas").gameObject;
        ScareText = canvas.transform.Find("ScaryPoint").gameObject;

        player.Gameplay.Grabbing.performed += context => OnGrabbing();
        player.Gameplay.Grabbing.canceled += context => ReleaseObject();
        player.Gameplay.Clean.performed += context => CleanObject();
       

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

        //Then, calculate the human condition
        if(onHuman){
            humanTask();
            onBody();
            lightScare();
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
            movement = new Vector3(moveVec.x, 0.0f ,moveVec.y);
            Nathan.transform.Translate(movement * ((float)baseSpeed/2) * Time.deltaTime, Space.World);
            if(movement != Vector3.zero)
            {
                Nathan.transform.rotation = Quaternion.LookRotation(new Vector3(moveVec.x, 0 ,moveVec.y));
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
        //Edited BY Guanchen
        if (!lightSwitch)
        {
            worldLighting.SetActive(!(worldLighting.activeSelf));
        }
    }

    void OnMusic()
    {
        AudioSource spookyClip = worldMusic.GetComponent<AudioSource>();

        //Edited BY Guanchen
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
        //Edited BY Guanchen
        if(!paintSwitch && !humanScript.isActive)
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

    //Add by Guanchen Liu
    void OnGrabbing(){
        if(humanScript.isActive){
            if(_selection != null){
            if(_selection.CompareTag("GrabObject")){      
                currentItem = selectedItem.GrabObject;
                grabItem = _selection;
            }
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
        //Edited BY Guanchen
        if(!humanScript.isActive){
            player.Gameplay.Enable();
        }
    }
    private void OnDisable()
    {
        player.Gameplay.Disable();
    }

    //Edited By Guanchen Liu
    //Access by Controller
    //This function will allow ghost take over the human
    //when the human is vaccan(?)
    void OnTaking(){
        print(this);
        if(!onHuman && !humanScript.isActive){
            var controlScript = this.GetComponent<GhostController>();
            rigBod.detectCollisions = false;
            var x = Nathan.transform.position.x;
            var y = this.transform.position.y;
            var z = Nathan.transform.position.z;
            this.transform.position = new Vector3(x,y,z);
            humanScript.isActive = true;
            scaryPoint = 100f;
            onHuman = true;
        }
    }

    //Edited By Guanchen Liu
    //Access by Controller
    //This function will allow ghost eject from the human
    //if scarypoint equals 0, ghosts will be forced eject
    void OnLeaving(){
        if(onHuman && humanScript.isActive){
            var rb = GetComponent<Rigidbody>();
            Vector3 randomDirection = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            rigBod.AddForce(randomDirection * (float)moveSpeed);
            scaryPoint = 100f;
            onHuman = false;
            humanScript.isActive = false;
            StartCoroutine(ExampleCoroutine());
        }

    }

    //Add by Guanchen Liu
    //Access by Controller
    //Back to title page
    void OnTitle(){
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

    //Add by Guanchen Liu
    //Origin: Enxuan
    //Access by Controller
    //This function will clean the dust when dust is nearby
    void CleanObject()
    {
        if(onHuman){
            if(_selection != null && _selection.CompareTag("CleanObject")) {
                currentItem = selectedItem.CleanObject;
            }
        }
    }
    //Add by Guanchen Liu
    //Origin: Enxuan
    //This function will calculate the distance between player and object
    bool checkItemInPos(Vector2 target, Vector2 item, float radius)
    {
        return Vector2.Distance(target, item) < radius;
    }

    //Add by Guanchen Liu
    //Test version
    //This function will decrease the scarypoint of character
    //when light is off. The ghost will eject out if the scarypoint
    //reach 0
    //Bug: The value of scaryPoint and lightOn should be recorded by another script
    void lightScare(){
        Text t = ScareText.GetComponent<Text>();
        if(!worldLighting.active){
            scaryPoint -= 0.2f;
        }
        t.text = "ScaryPoint: " + (int)scaryPoint;
        if(scaryPoint <= 0){
            scaryPoint = 100f;
            OnLeaving();
        }
    }
}
