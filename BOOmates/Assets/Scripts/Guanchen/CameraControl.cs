//Add by Guanchen Raymond Liu
//Version 1.0, Sprint1
//This script would move the camera from room to room
//depending on the character's position;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public  float       moveSpeed       = 20f;
    public  int         cameraCondition = 2;

    public  Quaternion  TargetRotation;
    public  Vector3     TargetRoom;
    //public  Vector3     RespawnPoint;
    public  bool        isMoving        = false;
    public  float       smoothTime      = 0.3F;
    private float       rotationSpeed   = 100f;
    private Vector3     velocity        = Vector3.zero;
    private Vector3     originPos;
    private Vector3     cutScenePos;
    private float       timer           = 1.5f;
    GameObject Nathan;
    HumanBehavior humanScript;
    GameObject CutSceneCamera;
    public TimeManager timeManager;
    void Start()
    {

        //Set a default position for the camera
        Nathan = GameObject.Find("Nathan");
        humanScript = Nathan.GetComponent<HumanBehavior>();
        CutSceneCamera = Nathan.transform.Find("cutScene").gameObject;
        TargetRoom = transform.position;
        originPos = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        //Condition:isMoving
        //Related to Script: DoorManagement.cs/43
        //Determing the moving condition of camera
        updateCutScenePos();
        if (isMoving){
        	CameraTransform(TargetRoom);
        }

        //Temp method
        //Kill all the clone stuff so game won't break
    }

    //Add by Guanchen Liu
    //This function will trigger when ghosts are swiping body
    
    public void DoCutScene(){
        isMoving = true;
        TargetRoom = cutScenePos;
        //timeManager.doSlowMotion();
        StartCoroutine(cameraCoroutine());

    }
    void updateCutScenePos(){
        var pos = Nathan.transform.position;
        pos.z -= 1.82f;
        pos.y += 3.0f;
        cutScenePos = pos;
    }

    IEnumerator cameraCoroutine(){
        yield return new WaitForSeconds(2f);
        TargetRoom = originPos;
        isMoving = true;
    }
    //Condition: Vector3 TargetRoom, Passed by doormanagement.cs
    //This function will actually moving the camera in to direct position
    void CameraTransform(Vector3 TargetRoom){
    	transform.position = Vector3.SmoothDamp(transform.position, TargetRoom, ref velocity, smoothTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, rotationSpeed * Time.deltaTime);
        fixPosition(TargetRoom);
    	if(Equal(transform.position, TargetRoom)){
    		isMoving = false;
            timer = 1.5f;
    	}
    }


    //This function will calculate two
    //Vector3 float number roundly
    bool Equal(Vector3 A, Vector3 B){
        int aX = (int)A.x;
        int aY = (int)A.y;
        int aZ = (int)A.z;
        int bX = (int)B.x;
        int bY = (int)B.y;
        int bZ = (int)B.z;
        return (aX == bX) && (aY == bY) && (aZ == bZ);
    }

    //This will fix the camera position when smoothdamp fucked up
    void fixPosition(Vector3 TargetRoom){
        if(!isMoving){
            timer = 1.5f;
        }else{
            timer -= Time.deltaTime;
            if(timer <= 0){
                transform.position = TargetRoom;

            }
        }
    }

}
