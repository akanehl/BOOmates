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
    public int     cameraCondition = 2;
    private Vector3 FirstRoom;
    private Vector3 SecondRoom;
    private Vector3 ThirdRoom;
    private Vector3 ForthRoom;
    public  Vector3 TargetRoom;
    public bool    isMoving = false;
    public  float   smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public GameObject player;
    void Start()
    {
        FirstRoom = new Vector3(0f,10f,-7.3f);
        SecondRoom = new Vector3(13.8f,10f,-7.3f);
        ThirdRoom = new Vector3(-15.5f,10f,-7.3f);
        ForthRoom = new Vector3(-15.5f,10f,-22f);
        transform.position = SecondRoom;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving){
        	CameraTransform(cameraCondition);
        }
        //Debug.Log(isMoving);
    }

    void CameraTransform(int camera){
    	var TargetCamera = new Vector3();
        switch (camera)
        {
            case 1:
                TargetCamera = FirstRoom;
                break;
            case 2:
                TargetCamera = SecondRoom;
                break;
            case 3:
                TargetCamera = ThirdRoom;
                break;
            case 4:
                TargetCamera = ForthRoom;
                break;
        }

    	transform.position = Vector3.SmoothDamp(transform.position, TargetCamera, ref velocity, smoothTime);
    	if(transform.position == TargetCamera){
    		isMoving = false;
    	}
    }

    // void checkRoom(){
    //     if(player.transform.position.x < (transform.position.x - 7) && cameraCondition == 1){
    //         cameraCondition = 3;
    //         isMoving = true;
    //     }
    //     if(player.transform.position.x > (transform.position.x + 7) && cameraCondition == 1){
    //         cameraCondition = 2;
    //         isMoving = true;
    //     }
    // }
}
