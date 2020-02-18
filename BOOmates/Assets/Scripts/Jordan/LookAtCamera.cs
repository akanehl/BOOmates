using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private GameObject emoteBubble;

    private Camera mainCam;

    // On start up finds camera and then turns off image. Passes ref to UIManager
    void Start()
    {

        mainCam = FindObjectOfType<Camera>();
        if (emoteBubble != null)
        {
            UIManager.instance.SetEmoteBubble(emoteBubble);
        }
        emoteBubble.SetActive(false);
    }

    // Update makes sure that when this is active the icon will always be visiable to the camera if it moves.
    void Update()
    {
        transform.LookAt(mainCam.transform);
    }
}
