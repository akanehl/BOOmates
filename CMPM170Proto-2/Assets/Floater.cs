using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{

    Vector3 posOffset = new Vector3();
    Vector3 temporary = new Vector3();

    public float amplitude;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        temporary = posOffset;
        temporary.y += Mathf.Sin(Time.fixedTime * Mathf.PI * speed) * amplitude;

        transform.position = temporary;
    }
}
