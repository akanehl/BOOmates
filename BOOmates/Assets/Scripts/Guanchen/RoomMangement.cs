using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMangement : MonoBehaviour
{
	public GameObject human;
	public GameObject thisRoom;
	private GameObject mainCamera;
	private GameObject doorWay;
	private int cameraCondition;
    // Start is called before the first frame update
    void Start()
    {
        GetChildWithName(thisRoom, "cameraPos");
        mainCamera = GameObject.Find("MainCamera");
        CameraControl sc = mainCamera.GetComponent<CameraControl>();
        cameraCondition = sc.cameraCondition;
        doorWay = thisRoom.transform.Find("doorWay").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //checkMoving();
    }
    GameObject GetChildWithName(GameObject obj, string name) {
     	Transform trans = obj.transform;
     	Transform childTrans = trans. Find(name);
     	if (childTrans != null) {
         	return childTrans.gameObject;
     	} else {
         	return null;
     		}
 		}

 	// void checkMoving(){
 	// 	CameraControl sc = mainCamera.GetComponent<CameraControl>();
 	// 	if(sc.isMoving){
 	// 		Debug.Log("Moving");
 	// 	}
 	// }
}
