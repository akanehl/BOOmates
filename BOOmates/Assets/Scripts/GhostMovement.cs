using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{

    public Rigidbody rigBod;
    public double moveSpeed;

    public string AxisNameHoriz;
    public string AxisNameVert;

    public KeyCode punchKey;

    public float punchForce =0;
    public float moveMod = 0;
    private double saveSpeed;
    private float maxPunch = 50;
    private bool punchCoolDown = false;
    
    Quaternion rotation = new Quaternion();
    void Start()
    {
        saveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.SetPositionAndRotation(transform.position, rotation);

        float moveHorizontal = Input.GetAxis(AxisNameHoriz);
        float moveVertical = Input.GetAxis(AxisNameVert);

        //Debug.Log(moveHorizontal + " " + moveVertical);

        

        //Debug.Log(movement);

        

        if (!punchCoolDown)
        {
            if(Input.GetKey(punchKey))
            {
                if (punchForce < maxPunch)
                {
                    punchForce++;
                }
                moveSpeed = moveSpeed / 1.1;
                moveHorizontal = -moveHorizontal;
                moveVertical = -moveVertical;
            }
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigBod.AddForce(movement * (float)moveSpeed);

        //Excecute punch and add punch force.
        if (Input.GetKeyUp(punchKey))
            {
               // Debug.Log(punchForce);
                moveMod = punchForce * 25;
                rigBod.AddForce(movement * moveMod);
                moveSpeed = saveSpeed;
                punchCoolDown = true;
                StartCoroutine(Wait());
            }
        

        IEnumerator Wait()
        {
            yield return  new WaitForSeconds(1);
            //Debug.Log("Reset Punch Force");
            punchForce = 0;
            punchCoolDown = false;
        }
    }
}
