using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingScript : MonoBehaviour
{
    float distance1;
    float distance2;
    public bool locked1;
    public bool locked2;
    GameObject[] ghosts;
    // Start is called before the first frame update
    void Start()
    {
        locked1 = true;
        locked2 = true;
        distance1 = 2;
        distance2 = 2;

    }

    // Update is called once per frame
    void Update()
    {
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");

        distance1 = Vector3.Distance(transform.position, ghosts[0].transform.position);
        
        distance2 = Vector3.Distance(transform.position, ghosts[1].transform.position);
        


        if (distance1 < 1)
        {
            unlockSwitch(0);
        }
        else
        {
            lockSwitch(0);
        }


        if (distance2 < 1)
        {
            unlockSwitch(1);
        }
        else
        {
            lockSwitch(1);
        }

    }

    void unlockSwitch(int num)
    {
        if (num == 0)
        {
            locked1 = false;
        }
        if (num == 1)
        {
            locked2 = false;
        }

        if (ghosts[num].transform.childCount > 0)
        {
            ghosts[num].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    void lockSwitch(int num)
    {
        if (num == 0)
        {
            locked1 = true;
        }
        if (num == 1)
        {
            locked2 = true;
        }

        if (ghosts[num].transform.childCount > 0)
        {
            ghosts[num].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
        }
    }


}
