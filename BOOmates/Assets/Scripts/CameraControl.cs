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
    public float moveSpeed = 20f;
    private int cameraCondition = 1;
    private Vector3 FirstRoom;
    private Vector3 SecondRoom;
    private Vector3 ThirdRoom;
    private Vector3 ForthRoom;
    private bool isMoving = false;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        FirstRoom = new Vector3(110f,283f,131f);
        SecondRoom = new Vector3(-150f,283f,131f);
        ThirdRoom = new Vector3(0f,283f,353f);
        transform.position = FirstRoom;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
        	isMoving = true;
            cameraCondition = 1;
        }else if (Input.GetKeyDown("2"))
        {
            isMoving = true;
            cameraCondition = 2;
        }else if (Input.GetKeyDown("3"))
        {
            isMoving = true;
            cameraCondition = 3;
        }
        if (isMoving){
        	CameraTransform(cameraCondition);
        }
        //Debug.Log(isMoving);
    }

    void CameraTransform(int camera){
    	var TargetCamera = new Vector3();
    	if(camera == 1){
    		TargetCamera = FirstRoom;
    	}else if(camera == 2){
    		TargetCamera = SecondRoom;
    	}else{
            TargetCamera = ThirdRoom;
        }

    	transform.position = Vector3.SmoothDamp(transform.position, TargetCamera, ref velocity, smoothTime);
    	if(transform.position == TargetCamera){
    		isMoving = false;
    	}
    }
}
