using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{

    public Rigidbody rigBod;
    public float moveSpeed;

    Vector3 posOffset = new Vector3();
    Vector3 temporary = new Vector3();

    public float amplitude;
    public float speed;

    public string AxisNameHoriz;
    public string AxisNameVert;


    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        temporary = posOffset;
        temporary.y += Mathf.Sin(Time.fixedTime * Mathf.PI * speed) * amplitude;

        transform.position = temporary;

        float moveHorizontal = Input.GetAxis(AxisNameHoriz);
        float moveVertical = Input.GetAxis(AxisNameVert);

        //Debug.Log(moveHorizontal + " " + moveVertical);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Debug.Log(movement);

        rigBod.AddForce(movement * moveSpeed);

   
    }
}
