using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagement : MonoBehaviour
{
	public GameObject human;
	private GameObject player1;
	private GameObject player2;
	private GameObject mainCamera;
	public GameObject doorWay;
	private int cameraCondition;
	private CameraControl sc;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
        player1 = GameObject.Find("Ghost_1");
        player2 = GameObject.Find("Ghost_2");
        sc = mainCamera.GetComponent<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
    	if(other.gameObject.name == "Ghost_2"){
    		var parentRoom = doorWay.transform.parent.gameObject;
    		var TargetRoom = parentRoom.transform.Find("cameraPos").gameObject.transform.position;
    		var RespawnPoint = parentRoom.transform.Find("RespawnPoint").gameObject.transform.position;
    		sc.TargetRoom = TargetRoom;
    		// if(sc.isMoving){
    		// 	player1.transform.position = RespawnPoint;
      		//  player2.transform.position = RespawnPoint;
    		// }
    		if(TargetRoom != sc.transform.position){
    			sc.RespawnPoint = parentRoom.transform.position;
    			sc.isMoving = true;
    			player1.transform.position = RespawnPoint;
      		    player2.transform.position = RespawnPoint;
    		}
    	}
    }
}
