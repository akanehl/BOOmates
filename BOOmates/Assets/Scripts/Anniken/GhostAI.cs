using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class GhostAI : MonoBehaviour
{
    //General Player Info
    static int numplayers = 0;
    public int playernum;
    public Rigidbody rigBod;
    private double moveSpeed;
    private double baseSpeed = 4;

    private float propTime;
    
    //Add by Guanchen Liu
    //Nathan info
    GameObject Nathan;
    HumanBehavior humanScript;
    public bool onHuman = false;
    public float scarePoint = 0f;
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
    private float lightCooldown;
    private bool lightEnable = true;
    Image lightImage;
    GameObject backUpLighting;

    //Gramophone variables
    private bool gramBool = false;
    static bool musicPlaying = false;
    GameObject gramophone;
    GramophoneScript musicScript;
    GameObject worldMusic;
    private float musicCooldown;
    private bool musicEnable = true;
    Image musicImage;
    
    //Painting variables
    private bool paintBool = false;
    bool hiding = false;
    GameObject painting;
    PaintingScript paintScript;
    private float paintCooldown;
    private bool paintEnable;
    Image paintImage;

    // Prop Variables
    public float pushForce;
    private bool propBool = false;
    public bool inProp = false;
    GameObject prop;
    PropScript propScript;

    //Material/Invisibility controls
    private float invisVal = 0;
    private bool dissapearing = false;

    //Add by Guanchen Liu
    //Combining human script and ghost script together
    public enum selectedItem {GrabObject, CleanObject, None}
    public selectedItem currentItem;
    public enum ghostCond {inHuman,onEjecting,None}
    public ghostCond currentCond;
    private Transform _selection;
    private Transform grabItem;
    //Add by Guanchen Liu
    //Find other gameobject
    private GameObject OtherGhost;
    private GameObject mainCamera;
    private bool freezeHuman;

    [SerializeField]
    private GameObject UI;

    private CameraControl sc;

    private bool _enabled = false;

    public Chores currentChore;
    private float cleanTimer;
    public ChoreMangerAI choreManger;


    private void Awake()
    {
        //Assign light variables to proper objects in scene
        lightSwitch = GameObject.FindGameObjectWithTag("Lights");
        worldLighting = GameObject.FindGameObjectWithTag("EnvironmentLights");
        backUpLighting = GameObject.FindGameObjectWithTag("BackUpLights");
        lightScript = lightSwitch.GetComponent<LightScript>();
        lightCooldown = 10f;
        lightEnable = true;
    
        //Assign gramophone variables to proper objects in scene
        gramophone = GameObject.FindGameObjectWithTag("Gramophone");
        worldMusic = GameObject.FindGameObjectWithTag("WorldMusic");
        musicScript = gramophone.GetComponent<GramophoneScript>();
        musicCooldown = 10f;
        musicEnable = true;

        //Assign painting variables to proper objects in scene
        painting = GameObject.FindGameObjectWithTag("Painting");
        paintScript = painting.GetComponent<PaintingScript>();
        paintCooldown = 15f;
        paintEnable = true;

        prop = GameObject.FindGameObjectWithTag("Prop");
        propScript = prop.GetComponent<PropScript>();

        //Assign player numbers and color

        //Add by Guanchen Liu
        //Assign nathan
        Nathan = GameObject.Find("Nathan");
        humanScript = Nathan.GetComponent<HumanBehavior>();
        currentItem = selectedItem.None;
        currentCond = ghostCond.None;
        mainCamera  = GameObject.Find("MainCamera");
        sc          = mainCamera.GetComponent<CameraControl>();
        var UICoolDown = UI.transform.Find("CoolDown").gameObject;
        
        // lightImage = UICoolDown.transform.GetChild(0).GetComponent<Image>();
        // musicImage = UICoolDown.transform.GetChild(1).GetComponent<Image>();
        // paintImage = UICoolDown.transform.GetChild(2).GetComponent<Image>();

        GameObject temp = GameObject.Find("Ghost_2");
        transform.position = temp.transform.position;
        Destroy(temp);
            

        var allGhost = GameObject.FindGameObjectsWithTag("Ghost");
     }


    private void FixedUpdate()
    {
        findOther();
        //Then, Dash Calculations
        doDash();
        //Update the ScarePoint Value, due to conditions
        //scareManager();
        //CoolDownManager();
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

        //Then, calculate the human condition tasks
        if (onHuman)
        {

            humanTask();
            onBody();
            scareManager();
            // timeSwiping();

        }
        //NEEDS TO BE UPDATED TO WORK WITH MULTIPLE ITEMS
       
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
        
        if(inProp)
        {
            if(propTime > 0.0f)
            {
                propTime -= Time.deltaTime;
            }
            else
            {
                OnLeave();
            }
        }
        

        if(!worldLighting.activeSelf)
        {
            Debug.Log("is light off");
            transform.GetChild(0).GetComponent<Renderer>().material.SetFloat("Boolean_4E9E1931", 1);
        }
        else
        {
            transform.GetChild(0).GetComponent<Renderer>().material.SetFloat("Boolean_4E9E1931", 0);
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
            rigBod.AddForce(dashForce * 10, 0.0f, dashForce * 10);
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
            Nathan.transform.Find("Firefly").gameObject.SetActive(true);
            currentCond = ghostCond.onEjecting;
            //OnLeaving();
            //var otherScript = OtherGhost.GetComponent<GhostController>();
            //otherScript.OnTaking();
        }

        if(scarePoint < 100)
        {
            //Nathan.transform.Find("Firefly").gameObject.SetActive(false);
            currentCond = ghostCond.inHuman;
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
        // Debug.Log(gramBool);
        //Edited BY Guanchen
        if (!lightBool && lightEnable && !inProp)
        {
            worldLighting.SetActive(!(worldLighting.activeSelf));
            lightEnable = false;
            backUpLighting.gameObject.SetActive(!backUpLighting.activeSelf);
            StartCoroutine(lightCoroutine());
        }
    }

    IEnumerator lightCoroutine(){
       yield return new WaitForSeconds(4);
       lightEnable = true;
        worldLighting.SetActive(!(worldLighting.activeSelf));
        backUpLighting.gameObject.SetActive(!backUpLighting.activeSelf);
    }
    

    void OnMusic()
    {
        //Edited BY Guanchen
     
    
            AudioSource spookyClip = worldMusic.GetComponent<AudioSource>();
            if (!gramBool && musicEnable && !inProp)
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
                    // musicPlaying = false;
                    // musicEnable  = false;
                    // musicImage.fillAmount = 0;

                }       
            }
        
    }

    void OnHide()
    {
        //Edited BY Guanchen
        if (!paintBool && paintEnable && !inProp)
        {

            //player isnt already hiding
            if (!hiding)
            {
                //Edit by Guanchen Liu
                //Fix the problem that ghost's y value would change
                //when ever it goes into the painting
                var targetPos = painting.transform.GetChild(0).transform.position;
                targetPos.y = transform.position.y;
                transform.position = targetPos;
                rigBod.constraints = RigidbodyConstraints.FreezePosition;
                Debug.Log(transform.position);
                
                hiding = true;
            }
            else
            {
                rigBod.constraints = RigidbodyConstraints.None;
                rigBod.constraints = RigidbodyConstraints.FreezePositionY;
                var targetPos = painting.transform.GetChild(1).transform.position;
                targetPos.y = transform.position.y;
                transform.position = targetPos;
                Debug.Log(transform.position);
                rigBod.AddForce((1) * 500, 0.0f, (1) * 500);
                hiding = false;
                if (Vector3.Distance(transform.position, Nathan.transform.position) < 5)
                {

                    var otherScript = OtherGhost.GetComponent<GhostController>();
                    otherScript.scarePoint += 75;
                }
                // paintEnable = false;
                // paintImage.fillAmount = 0;
                // Debug.Log(scarePoint);
                //human scare point logic
            }
        }
    }


    public void OnEnter()
    {
        // Ghost enters a prop
      
        // If the ghost is in a prop
        if (inProp && !onHuman)
        {
            var heading = Nathan.transform.position - transform.position;
            var moving = heading;
            prop.GetComponent<Rigidbody>().velocity = moving * 10f;
            gameObject.transform.position = prop.transform.position;
        }


        //the ghost is not in a prop, and close enough to active
        Debug.Log(propBool);
        if (!propBool && !onHuman)
        {
            if (!inProp)
            {
                inProp = true;
                gameObject.transform.position = prop.transform.position;
                baseSpeed = 0;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                propTime = 2.0f;
                prop.GetComponent<PropScript>().onProp = true;
            }
        }

    }

    public void OnLeave()
    {
        Debug.Log("Attempting to leave");
        if (inProp)
        {
            Debug.Log("Attempting to leave the object");
            inProp = false;
            prop.GetComponent<PropScript>().onProp = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            baseSpeed = 4;
            Vector3 resetPos = new Vector3(0, 0.5f, 0);
            gameObject.transform.position = resetPos;
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
    private void OnInvis()
    {
        dissapearing = true;
    }

    private void OnAppear()
    {
        dissapearing = false;
    }

    /*--------------------------------------------------------------------------------------------------------------------*/
    /* ------------------------------------HUMAN INTERACTION METHODS------------------------------------------------------*/
    /*--------------------------------------------------------------------------------------------------------------------*/

    //Add by Guanchen Liu
    void OnGrabbing(){
        if(!humanScript.enabled)
        {
            //Debug.Log("pressed");
            if(_selection != null)
            {
                if(_selection.CompareTag("GrabObject") && !_selection.GetComponent<Chores>().complete())
                {
                    currentItem = selectedItem.GrabObject;
                    grabItem = _selection;
                    _selection.GetComponent<Chores>().getTargetPosition().SetActive(true);
                }
                else if( _selection.CompareTag("CleanObject") && !_selection.GetComponent<Chores>().complete()) 
                {
                    currentItem = selectedItem.CleanObject;
                }
                currentChore = _selection.GetComponent<Chores>();
            }
        }
    }

    //Edited By Guanchen Liu
    //Access by Controller
    //This function will allow ghost take over the human
    //when the human is vaccan(?)
    void OnTaking(){

        //Debug.Log("pressed in taking");
        if(!onHuman && humanScript.enabled && !inProp){
            var controlScript = this.GetComponent<GhostController>();
            rigBod.detectCollisions = false;
            scarePoint = 0;
            transform.GetChild(0).gameObject.SetActive(false);
            humanScript.enabled = false;
            onHuman = true;
            var vfx = Nathan.transform.Find("Firefly").gameObject;
            vfx.SetActive(false);
            choreManger.setPlayer(this.gameObject);
            if(Nathan.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled)
            {
                Nathan.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
                Nathan.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                GameObject.Find("NavMesh Surface").SetActive(false);
            }
            var x = Nathan.transform.position.x;
            var y = 0.5f;
            var z = Nathan.transform.position.z;
            this.transform.position = new Vector3(x,y,z);
        }
    }

    //Edited By Guanchen Liu
    //Access by Controller
    //This function will allow ghost eject from the human
    //if scarePoint equals 0, ghosts will be forced eject
    public void OnLeaving(){
        if(onHuman && !humanScript.enabled){
            scarePoint = 0;
            var rb = GetComponent<Rigidbody>();
            Vector3 randomDirection = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            rigBod.AddForce(randomDirection * (float)moveSpeed);
            
            //sc.TargetRoom = Nathan.transform.GetChild(3).transform.position;
            //sc.isMoving = true;
            //Handheld.Vibrate();
            onHuman = false;
            humanScript.enabled = true;
            freezeHuman = true;
            if(_selection != null){
                _selection.transform.parent = GameObject.Find("Chores").transform;
                _selection.GetComponent<Rigidbody>().useGravity = true;
            }
            transform.GetChild(0).gameObject.SetActive(true);
            if(Nathan.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled){
                Nathan.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
            }
            Nathan.transform.Find("Aura").gameObject.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }

    }

    //Add by Guanchen Liu
    //Edited BY Jordan Timm
    //Access by Controller
    //opens pause menu for now
    void OnTitle(){
        UIManager.instance.TogglePause();
    }
    void OnPause()
    {
        UIManager.instance.TogglePause();
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
       yield return new WaitForSeconds(1f);
       rigBod.detectCollisions = true;
       freezeHuman = false;
       yield return new WaitForSeconds(2f);
       Nathan.transform.Find("Aura").gameObject.SetActive(false);
    }

    //Add by Guanchen Liu
    //Origin: Enxuan
    //Modified: Jordan Timm
    //Mods: Changed physcial items to UI based elements
    //This function will go through the human interaction when ghosts
    //on human.
    void humanTask(){
        if(!freezeHuman){
            //_selection.GetComponent<Rigidbody>().isKinematic = true;
            
            if(currentItem == selectedItem.GrabObject)
            {
                if(_selection != null)
                {
                    UIManager.instance.UpdateChore(_selection.GetComponent<Chores>());
                    UIManager.instance.TriggerHintDeactivate();
                    //Sound: Grab Item Sound
                    Debug.Log("isgrabbing");
                    var grabPosition = Nathan.transform.Find("holdingPos").gameObject;
                    var selectRigid = _selection.GetComponent<Rigidbody>();
                    _selection.transform.position = grabPosition.transform.position;
                    _selection.transform.parent = Nathan.transform;
                    _selection.transform.forward = Nathan.transform.forward;
                    // selectRigid.constraints =  RigidbodyConstraints.FreezeRotation;
                    selectRigid.useGravity = false;
                    //_selection.GetComponent<Rigidbody>().isKinematic = true;
                    // _selection.transform.position = Nathan.transform.position + Nathan.transform.forward * 1 + new Vector3(0.0f, -Nathan.transform.position.y, 0.0f);
                    // _selection.transform.rotation = Quaternion.LookRotation(Nathan.transform.forward);
                }
            }
            else if(currentItem == selectedItem.CleanObject)
            {
                UIManager.instance.TriggerHintDeactivate();

                if (_selection != null)
                {
                    UIManager.instance.UpdateChore(_selection.GetComponent<Chores>());

                    Nathan.GetComponent<Rigidbody>().isKinematic = true;
                    //Sound: Clean Sound around 5 seconds

                    //Turn on CleanTimer
                    UIManager.instance.CleanTimerToggle(true);
                    //Nathan.transform.GetChild(2).gameObject.SetActive(true);
                    //Nathan.transform.GetChild(2).transform.rotation = Quaternion.Euler(new Vector3 (0.0f, 0.0f, 0.0f));
                    //Transform timeBar = Nathan.transform.GetChild(2).GetChild(0);
                    if(cleanTimer < 1)
                    {
                        cleanTimer += Time.deltaTime * 0.2f;
                        UIManager.instance.UpdateCleanTimer(cleanTimer);

                    }
                    else
                    {
                        _selection.gameObject.SetActive(false);
                        cleanTimer = 0;

                        //Vector3 lTemp = timeBar.localScale;
                        //lTemp.x = 0.0f;
                        //timeBar.localScale = lTemp;

                        UIManager.instance.CleanTimerToggle(false);
                        UIManager.instance.UpdateCleanTimer(cleanTimer);

                        //Nathan.transform.GetChild(2).gameObject.SetActive(false);
                        _selection = null;
                        currentChore.finishClean();
                        currentItem = selectedItem.None;
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
                        Nathan.transform.GetChild(3).gameObject.SetActive(true);
                        if(hit.transform.CompareTag("GrabObject")){
                            UIManager.instance.TriggerHint(0);
                            //Nathan.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
                            //Nathan.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                            _selection = hit.transform;
                        }
                        else if (hit.transform.CompareTag("CleanObject"))
                        {
                            UIManager.instance.TriggerHint(1);
                            //Nathan.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
                            //Nathan.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
                            _selection = hit.transform;
                        }
                        else
                        {
                            UIManager.instance.TriggerHintDeactivate();
                            //Nathan.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
                            //Nathan.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                            _selection = null;
                        }
                    }
                }
                else
                {
                    UIManager.instance.TriggerHintDeactivate();
                    //Nathan.transform.GetChild(3).gameObject.SetActive(false);
                    _selection = null;
                }

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
                _selection.transform.parent = GameObject.Find("Chores").transform;
                
                currentItem = selectedItem.None;
                var selectRigid = grabItem.gameObject.GetComponent<Rigidbody>();
                selectRigid.useGravity = true;
                grabItem.GetComponent<Chores>().getTargetPosition().SetActive(false);
                selectRigid.constraints =  RigidbodyConstraints.None;
                //test
                currentChore.placed();
                grabItem = null;
                currentChore = null;
            }
        }
    }

    //Add by Guanchen liu
    //An interesting function that allow player to throw stuff
    void OnThrow(){
        if(currentItem == selectedItem.GrabObject && onHuman){
            _selection.transform.parent = GameObject.Find("Chores").transform;
            currentItem = selectedItem.None;
            grabItem.GetComponent<Chores>().getTargetPosition().SetActive(false);
            var selectRigid = grabItem.gameObject.GetComponent<Rigidbody>();
            selectRigid.velocity = Nathan.transform.forward * 10f;
            selectRigid.useGravity = true;
            selectRigid.constraints =  RigidbodyConstraints.None;
            grabItem = null;
            currentChore = null;
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
    // void timeSwiping(){

    //     if(onHuman){
    //         swipeTime -= 0.02f;
    //     }
    //     if(swipeTime <= 0f){
    //         //onHuman = false;
    //         OnLeaving();
    //         var otherScript = OtherGhost.GetComponent<GhostController>();
    //         otherScript.OnTaking();
    //         swipeTime = 15f;
    //     }

    //    UIManager.instance.UpdateTimer((int)swipeTime);
    // }

    void findOther(){
        if(Time.timeScale == 1.0f)
        {
            OtherGhost = GameObject.Find("Ghost_1");
        }
    }

    void OnCollisionEnter(Collision other){
        if(OtherGhost != null) {
            var otherScript = OtherGhost.GetComponent<GhostController>();
            if(other.gameObject.tag == "Human" && !onHuman){
                if(!otherScript.onHuman){
                    OnTaking();
                }else if(otherScript.currentCond == GhostController.ghostCond.onEjecting && !inProp){
                    Debug.Log("active");
                    currentItem = selectedItem.None;
                    otherScript.OnLeaving();
                    OnTaking();
                }
            }
        }
    }

    void CoolDownManager(){
        if(!paintEnable){
            paintImage.fillAmount += 1 / lightCooldown * Time.deltaTime;
            paintCooldown -= 0.02f;
            if(paintCooldown <= 0){
                paintEnable = true;
                paintCooldown = 15f;
            }
        }
        if(!lightEnable){
            lightImage.fillAmount += 1 / lightCooldown * Time.deltaTime;
            lightCooldown -= 0.02f;
            if(lightCooldown <= 0){
                lightEnable = true;
                lightCooldown = 15f;
            }
        }
        if(!musicEnable){
            musicImage.fillAmount += 1 / lightCooldown * Time.deltaTime;
            musicCooldown -= 0.02f;
            if(musicCooldown <= 0){
                musicEnable = true;
                musicCooldown = 15f;
            }
        }
    }

    public Chores getcurrentChore()
    {
        return currentChore;
    }
}
