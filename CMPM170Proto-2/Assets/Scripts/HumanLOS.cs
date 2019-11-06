using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanLOS : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //transform based on what this script is attached to, i.e. human
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.cyan);

        RaycastHit hit;

        if ((Physics.Raycast(ray, out hit) && (hit.transform != null) && (hit.transform.name == player1.transform.name))) 
        {
            Debug.Log(player1);
        }

    }
}
