using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{

    float p1Color;
    float p2Color;
    Renderer rend;

    public double moveSpeed;
    public Rigidbody rigBod;

    private string AxisNameHoriz;
    private string AxisNameVert;
    private bool controlsUnlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        p1Color = 0;
        p2Color = 0;
        InvokeRepeating("incrColor", 1f, 1f);  //1s delay, repeat every 1s
    }

    // Update is called once per frame
    void Update()
    {
        if(p1Color <50 && p2Color < 50)
        {
            rend.material.SetFloat("Vector1_85AC89E9", p1Color);
            rend.material.SetFloat("Vector1_90F0EA03", p2Color);
        }
        else if(p1Color >= 50)
        {
            rend.material.SetFloat("Vector1_85AC89E9", 50);
            rend.material.SetFloat("Vector1_90F0EA03", 0);
            CancelInvoke();
            //controls to p1
            setAxis(0);
            controlsUnlocked = true;
        }
        else if(p2Color >= 50)
        {
            rend.material.SetFloat("Vector1_85AC89E9", 0);
            rend.material.SetFloat("Vector1_90F0EA03", 50);
            CancelInvoke();
            //controls to p2
            setAxis(1);
            controlsUnlocked = true;
        }

        if(controlsUnlocked)
        {
            float moveHorizontal = Input.GetAxis(AxisNameHoriz);
            float moveVertical = Input.GetAxis(AxisNameVert);

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rigBod.AddForce(movement * (float)moveSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision!");

        float punchForce = 0;

        if(collision.gameObject.tag == "Ghost1")
        {
            punchForce = collision.gameObject.GetComponent<GhostMovement>().punchForce;
            Debug.Log(punchForce);
            punchForce = punchForce / 4;
            Debug.Log(punchForce);
            // Debug.Log("p1 collide");
            if (p1Color <50)
            p1Color += punchForce;
            if (p1Color >= 50)
                collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Ghost2")
        {
            punchForce = collision.gameObject.GetComponent<GhostMovement>().punchForce;
            Debug.Log(punchForce);
            punchForce = punchForce / 4;
            Debug.Log(punchForce);
            if (p2Color <50)
            p2Color += punchForce;
            if (p2Color > 50)
                collision.gameObject.SetActive(false);
        }
    }

    void incrColor()
    {
        if(p1Color > 0)
        {
            p1Color -= 3;
        }
        if(p2Color >0)
        {
            p2Color -= 3;
        }
        
    }
    void setAxis(int stat)
    {
        if( stat == 0)
        {
            //p1 axis;
            AxisNameHoriz = "Player1Horizontal";
            AxisNameVert = "Player1Vertical";
        }
        if (stat ==1)
        {
            //p2 axis;
            AxisNameHoriz = "Player2Horizontal";
            AxisNameVert = "Player2Vertical";
        }
    }

}
