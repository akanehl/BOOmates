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
    public  float   moveSpeed = 20f;
    public  int     cameraCondition = 2;
    //private Vector3 FirstRoom;
    private Vector3 SecondRoom;
    //private Vector3 ThirdRoom;
    //private Vector3 ForthRoom;
    public  Vector3 TargetRoom;
    public  Vector3 RespawnPoint;
    public  bool    isMoving = false;
    public  float   smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public  GameObject player1;
    public  GameObject player2;
    void Start()
    {
        //FirstRoom = new Vector3(0f,10f,-7.3f);
        SecondRoom = new Vector3(13.8f,10f,-7.3f);
        //ThirdRoom = new Vector3(-15.5f,10f,-7.3f);
        //ForthRoom = new Vector3(-15.5f,10f,-22f);
        transform.position = SecondRoom;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving){
        	CameraTransform(TargetRoom);
        }
        //Debug.Log(isMoving);
    }

    void CameraTransform(Vector3 TargetRoom){
    	transform.position = Vector3.SmoothDamp(transform.position, TargetRoom, ref velocity, smoothTime);
        playerRespawn();
    	if(transform.position == TargetRoom){
    		isMoving = false;
    	}
    }

    void playerRespawn(){
        // player1.transform.position = RespawnPoint;
        // player2.transform.position = RespawnPoint;
    }
}
