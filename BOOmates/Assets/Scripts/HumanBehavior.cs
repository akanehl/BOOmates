using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanBehavior : MonoBehaviour
{
    public enum HumanState {NORMAL, CONTROL}

    public enum selectedItem {GrabObject, CleanObject, None}

    private selectedItem currentItem;
    private HumanState currentState;

    [SerializeField]
    private float speed;
    
    GameObject grabObj;

    public Transform[] moveSpots; 
    private int randomSpot;

    private float waitTime;

    [SerializeField]
    private float startWaitTime;

    MyHumanController myControls;

    Vector2 myMove;

    private Transform _selection;

    void Awake()
    {
        myControls = new MyHumanController();
        myControls.GamePlay.TakeBody.performed += context => TakeBody();
        myControls.GamePlay.LeaveBody.performed += context => LeaveBody();

        myControls.GamePlay.Grab.performed += context => GrabObject();
        myControls.GamePlay.Grab.canceled += context => ReleaseObject();

        myControls.GamePlay.MyMovement.performed += context => myMove = context.ReadValue<Vector2>();
        myControls.GamePlay.MyMovement.canceled += context => myMove = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        currentState = HumanState.NORMAL;
        waitTime = startWaitTime;
        currentItem = selectedItem.None;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentState == HumanState.NORMAL)
        {
            normalBehavior();
        }
        else
        {
            movement();
            if(currentItem == selectedItem.GrabObject)
            {
                if(_selection != null){
                    _selection.transform.position = transform.position + transform.forward * 25 + new Vector3(0.0f, 15.0f, 0.0f);
                }
            }
        }

    }

    //Human AI, move around when human isn't control by ghost(player)
    void normalBehavior()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, 
                                                    speed * Time.deltaTime);
        transform.LookAt(moveSpots[randomSpot].position);
        if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0) 
            {
                int prevRandomSpot = randomSpot;
                while (prevRandomSpot == randomSpot)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    void movement()
    {
        Vector3 moveVec = new Vector3(-myMove.x, 0.0f ,-myMove.y);
        transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
        if(moveVec != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-myMove.x, 0 ,-myMove.y));
        }
    }

    void OnEnable()
    {
        myControls.GamePlay.Enable();
    }

    void OnDisable()
    {
        myControls.GamePlay.Disable();
    }

    //take the body/take control by player
    void TakeBody()
    {
        Debug.Log("Control");
        currentState = HumanState.CONTROL;
        
    }

    //leave the body/back to AI
    void LeaveBody()
    {
        currentState = HumanState.NORMAL;
        Debug.Log("Normal");
    }

    void GrabObject()
    {      
        currentItem = selectedItem.GrabObject;
        _selection = getItem();
    }

    void ReleaseObject()
    {
        Debug.Log("Release Object");
        currentItem = selectedItem.None;
    }

    Transform getItem()
    {
        if(currentItem != selectedItem.None)
        {
            Ray ray = new Ray(transform.position, transform.forward); 
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 50.0f))
            {
                Transform selection = hit.transform;
                if(selection.transform.CompareTag("GrabObject")){
                    return selection;
                }
            }
        }
        return null;
    }
}
