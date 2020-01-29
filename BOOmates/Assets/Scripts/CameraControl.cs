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
    public  GameObject  player1;
    public  GameObject  player2;
    private float       timer           = 1.5f;
    void Start()
    {
        // //FirstRoom = new Vector3(0f,10f,-7.3f);
        // SecondRoom = new Vector3(13.8f,10f,-7.3f);
        // //ThirdRoom = new Vector3(-15.5f,10f,-7.3f);
        // //ForthRoom = new Vector3(-15.5f,10f,-22f);

        //Set a default position for the camera
        SecondRoom = new Vector3(88f, 244f, -239f);
        transform.position = SecondRoom;
        //transform.rotation = new Quaternion(55f,0f,0f,1);
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
    }

    void CameraTransform(Vector3 TargetRoom){
    	transform.position = Vector3.SmoothDamp(transform.position, TargetRoom, ref velocity, smoothTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, rotationSpeed * Time.deltaTime);
        fixPosition(TargetRoom);
    	if(Equal(transform.position, TargetRoom)){
    		isMoving = false;
            timer = 1.5f;
    	}
    }

    void playerRespawn(){
        // player1.transform.position = RespawnPoint;
        // player2.transform.position = RespawnPoint;
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
