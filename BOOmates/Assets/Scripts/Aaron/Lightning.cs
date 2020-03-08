using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{

    private Light lightning;
    public float minWaitTime;
    public float maxWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        lightning = GetComponent<Light>();
        lightning.enabled = false;
        StartCoroutine(Strike());    
    }

    IEnumerator Strike()
    {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            lightning.enabled = !lightning.enabled;//Turn light on
            yield return new WaitForSeconds(0.2f); //wait half a second
            lightning.enabled = !lightning.enabled; //turn off
            yield return new WaitForSeconds(0.2f);//wait half a second
            lightning.enabled = !lightning.enabled;//Turn light on
            yield return new WaitForSeconds(0.5f);//wait 1.5 seconds
            lightning.enabled = !lightning.enabled; //turn light off
        }

    }
}
