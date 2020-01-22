using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagement : MonoBehaviour
{
	public GameObject human;
	private GameObject mainCamera;
	public GameObject doorWay;
	private int cameraCondition;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
        CameraControl sc = mainCamera.GetComponent<CameraControl>();
        Debug.Log(mainCamera); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
    	if(other.gameObject.name == "Ghost_2"){
    		CameraControl sc = mainCamera.GetComponent<CameraControl>();
    		if(doorWay.transform.parent.name == "Room1"){
    			sc.cameraCondition = 1;

    		}else if(doorWay.transform.parent.name == "Room2"){
    			sc.cameraCondition = 2;
    		

    		}else if(doorWay.transform.parent.name == "Room3"){
    			sc.cameraCondition = 3;
    			
    			
    		}else if(doorWay.transform.parent.name == "Room4"){
    			sc.cameraCondition = 4;
    			
    			
    		}
    		sc.isMoving = true;
    	}
    }
}
