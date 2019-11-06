//"it's ok, Aaron", I say. "I'll save you". I gingerly
//kiss Sonic the Hedgehog and, lo and behold, Aaron's
//git-induced bullet wounds heal! It's a miracle!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanLOS : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    // Update is called once per frame
    void Update()
    {
        //transform based on what this script is attached to, i.e. human
        //-0.55 is magic number for ghost heights
        Ray ray = new Ray(transform.position + new Vector3(0, -0.55f, 0), transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.cyan);

        RaycastHit hit;

        if ((Physics.Raycast(ray, out hit)) && (hit.transform.name == player1.transform.name)) 
        {
            var humanSkin = transform.GetComponent<Renderer>();
            humanSkin.material.SetColor("_Color", Color.red);
        }
        else if ((Physics.Raycast(ray, out hit)) && (hit.transform.name == player2.transform.name))
        {
            var humanSkin = transform.GetComponent<Renderer>();
            humanSkin.material.SetColor("_Color", Color.blue);
        }
        else
        {
            var humanSkin = transform.GetComponent<Renderer>();
            humanSkin.material.SetColor("_Color", Color.white);
        }

    }
}