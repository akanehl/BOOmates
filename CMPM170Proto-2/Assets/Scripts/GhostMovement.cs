using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{

    public Rigidbody rigBod;
    public float moveSpeed;

    public string AxisNameHoriz;
    public string AxisNameVert;

    Quaternion rotation = new Quaternion();
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.SetPositionAndRotation(transform.position, rotation);

        float moveHorizontal = Input.GetAxis(AxisNameHoriz);
        float moveVertical = Input.GetAxis(AxisNameVert);

        //Debug.Log(moveHorizontal + " " + moveVertical);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Debug.Log(movement);

        rigBod.AddForce(movement * moveSpeed);

   
    }
}
