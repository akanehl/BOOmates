using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconTurnOff : MonoBehaviour
{
    private Camera mainCam;

    [SerializeField] private float turnOffDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = FindObjectOfType<Camera>();

        Invoke("TurnOff", turnOffDelay);
    }

    void Update()
    {
        transform.LookAt(mainCam.transform);
    }

    void TurnOff()
    {
        gameObject.SetActive(false);
    }

   
}
