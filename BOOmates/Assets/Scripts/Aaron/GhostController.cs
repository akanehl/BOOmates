using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class GhostController : MonoBehaviour
{
    //General Player Info
    static int numplayers = 0;
    public int playernum;
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
    private float swipeTime = 15f;


    //Dash Information
    private bool powerUp;
    private float dashForce = 0f;
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

    //Prop Variables
    public float pushForce;
    private bool propBool = false;
    bool inProp;
    GameObject prop;
    PropScript propScript;

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
    private Transform _selection;
    private Transform grabItem;
    //Add by Guanchen Liu
    //Find other gameobject
    private GameObject OtherGhost;
    private GameObject mainCamera;
    private CameraControl sc;

    private Chores currentChore;

    private ChoreManger choreManger;

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

        prop = GameObject.FindGameObjectWithTag("Prop");
        propScript = prop.GetComponent<PropScript>();

        //Assign player numbers and colors
        playernum = numplayers;
        numplayers++;

        //Add by Guanchen Liu
        //Assign nathan
        Nathan = GameObject.Find("Nathan");
        humanScript = Nathan.GetComponent<HumanBehavior>();
        currentItem = selectedItem.None;
        mainCamera  = GameObject.Find("MainCamera");
        sc          = mainCamera.GetComponent<CameraControl>();

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

        var allGhost = GameObject.FindGameObjectsWithTag("Ghost");

        //choreManger = GameObject.Find("ChoreManger").GetComponent<ChoreManger>();
    }

    private void FixedUpdate()
    {
        findOther();
        //First, we calculate movement speed+direction
        calculateMovement();
        //Secondly, calculate invisibility
        calculateInvisibility();
        //Then, Dash Calculations
        doDash();
        //Update the ScarePoint Value, due to conditions
        scareManager();

        if (playernum == 0)
        {
            painting = paintScript.closest1;
            prop = propScript.closest1;
        }
        if (playernum == 1)
        {
            painting = paintScript.closest2;
            prop = propScript.closest2;
        }

        if(currentChore == null)
        {
            if (playernum == 0)
            {

                //currentChore = choreManger.player1Chore;
            }
            else
            {
                //currentChore = choreManger.player2Chore;
            }
        }

        //Then, calculate the human condition tasks
        if (onHuman)
        {

            humanTask();
            onBody();
            scareManager();
            // timeSwiping();

        }
    
        else
        {
            if (playernum == 0)
            {
                lightBool = lightScript.locked1;
                gramBool = musicScript.locked1;
                paintBool = paintScript.locked1;
                propBool = propScript.locked1;
                
            }
            if (playernum == 1)
            {

                lightBool = lightScript.locked2;
                gramBool = musicScript.locked2;
                paintBool = paintScript.locked2;
                propBool = propScript.locked2;
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
                if(movement != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(moveVec.x, 0 ,moveVec.y));
                }
    
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
    //Edited by: Jordan Timm (UI modification)
    //Test version
    //This function will decrease the scarePoint of character
    //when light is off. The ghost will eject out if the scarePoint
    //reach 0
    //Bug: The value of scarePoint and lightOn should be recorded by another script
    void scareManager()
    {
        
        if(scarePoint > 100)
        {
            scarePoint = 0;
            OnLeaving();
            var otherScript = OtherGhost.GetComponent<GhostController>();
            otherScript.OnTaking();
        }

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

        UIManager.instance.UpdateScarePoints((int)scarePoint);
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
        //Edited BY Guanchen
     
    
            AudioSource spookyClip = worldMusic.GetComponent<AudioSource>();
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
                if(Vector3.Distance(transform.position, Nathan.transform.position) < 5)
                {
                    var otherScript = OtherGhost.GetComponent<GhostController>();
                    otherScript.scarePoint += 75.0f;
                }
                //human scare point logic
            }
        }
    }

    void OnEnter()
    {
        Debug.Log(propBool);
        //Ghost enters a prop

        //If the ghost is in a prop
        if (inProp)
        {
            prop.GetComponent<Rigidbody>().AddForce(moveVec.x * pushForce, 0.0f, moveVec.y * pushForce);
            Debug.Log("setting pos");
            gameObject.transform.position = prop.transform.position;
        }

        //the ghost is not in a prop, and close enough to active
        if (!propBool)
        {
            if (!inProp)
            {
                inProp = true;
                gameObject.transform.position = prop.transform.position;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);

            }
        }

    }

    void OnLeave()
    {
        if (inProp)
        {
            inProp = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void OnDash()
    {
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
        if(!humanScript.enabled)
        {
            Debug.Log("pressed");
            if(_selection != null && currentChore.gameObject == _selection.gameObject)
            {
                if(_selection.CompareTag("GrabObject") && currentChore is Grabs)
                {      
                    currentItem = selectedItem.GrabObject;
                    grabItem = _selection;
                }
                else if( _selection.CompareTag("CleanObject") && currentChore is Cleans) 
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

        Debug.Log("pressed in taking");
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
            
            //sc.TargetRoom = Nathan.transform.GetChild(3).transform.position;
            //sc.isMoving = true;
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

    void OnNextChore()
    {
        currentChore = choreManger.nextChore(playernum);
        UIManager.instance.UpdateChore(currentChore);
    }

    void OnPrevChore()
    {
        currentChore = choreManger.prevChore(playernum);
        UIManager.instance.UpdateChore(currentChore);
    }

    //Add by Guanchen Liu
    //Origin: Enxuan
    //This function will go through the human interaction when ghosts
    //on human.
    void humanTask(){
          if(currentItem == selectedItem.GrabObject && currentChore is Grabs)
            {
                if(_selection != null)
                {
                    //Sound: Grab Item Sound
                    _selection.transform.position = Nathan.transform.position + Nathan.transform.forward * 1 + new Vector3(0.0f, -Nathan.transform.position.y, 0.0f);
                    _selection.transform.rotation = Quaternion.LookRotation(Nathan.transform.forward);
                }
            }
            else if(currentItem == selectedItem.CleanObject && currentChore is Cleans)
            {
                if(_selection != null)
                {
                    //Sound: Clean Sound around 5 seconds
                    Nathan.transform.GetChild(0).gameObject.SetActive(true);
                    Nathan.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3 (0.0f, 0.0f, 0.0f));
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
                        currentChore.finishClean();
                        currentChore = null;
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
                if(grabItem.gameObject == currentChore.gameObject)
                {
                    currentChore.placed();
                    if(currentChore.complete())
                    {
                        currentChore = null;
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

    //Add by Guanchen Liu
    //Edited by: Jordan Timm (UI modification)
    //Origin: Guanchen
    //This function will swipe the possessions of the ghost after a specific time
    void timeSwiping(){

        if(onHuman){
            swipeTime -= 0.02f;
        }
        if(swipeTime <= 0f){
            //onHuman = false;
            OnLeaving();
            var otherScript = OtherGhost.GetComponent<GhostController>();
            otherScript.OnTaking();
            swipeTime = 15f;
        }

       UIManager.instance.UpdateTimer((int)swipeTime);
    }

    void findOther(){
        var allGhost = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject ghost in allGhost){
             if(ghost != this.gameObject){
                OtherGhost = ghost;
             }
        }
    }

    void OnCollisionEnter(Collision other){
        var otherScript = OtherGhost.GetComponent<GhostController>();
        if(other.gameObject.tag == "Human" && !onHuman && !otherScript.onHuman){
            OnTaking();
        }
    }
}
