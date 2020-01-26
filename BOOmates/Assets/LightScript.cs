using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    float distance;
    public bool locked;
    GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        locked = true;
        distance = 51;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ghost)
        {
            ghost = GameObject.FindGameObjectWithTag("Ghost");
        }
        else
        {
            distance = Vector3.Distance(transform.position, ghost.transform.position);
            
        }

        if(distance < 50)
        {
            unlockSwitch();
        }
        else
        {
            lockSwitch();
        }

    }

    void unlockSwitch()
    {
        locked = false;
        GameObject.FindGameObjectWithTag("Ghost").transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
    }
    void lockSwitch()
    {
        locked = true;
        GameObject.FindGameObjectWithTag("Ghost").transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
    }

        

}
