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
    //private Vector3 FirstRoom;
    private Vector3     SecondRoom;
    //private Vector3 ThirdRoom;
    //private Vector3 ForthRoom;
    public  Quaternion  TargetRotation;
    public  Vector3     TargetRoom;
    public  Vector3     RespawnPoint;
    public  bool        isMoving        = false;
    public  float       smoothTime      = 0.3F;
    private float       rotationSpeed   = 100f;
    private Vector3     velocity        = Vector3.zero;
    private float       timer           = 1.5f;
    void Start()
    {

        //Set a default position for the camera
        SecondRoom = new Vector3(-4.73f, 5.07f, 2.32f);
        transform.position = SecondRoom;

    }

    // Update is called once per frame
    void Update()
    {
        //Condition:isMoving
        //Related to Script: DoorManagement.cs/43
        //Determing the moving condition of camera
        if (isMoving){
        	CameraTransform(TargetRoom);
        }

        //Temp method
        //Kill all the clone stuff so game won't break
        killClone();
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

    void killClone(){
        var clone = GameObject.Find("Ghost(Clone)");

        Destroy(clone);

    }
}
