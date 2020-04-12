using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float lifeDuration = 4f;
    GameObject Nathan;
    private float lifeTimer;
    private bool onFly = true;
    private GameObject mainCamera;
    private List<GameObject> Boos = new List<GameObject>();
    void Start()
    {
        Nathan = GameObject.Find("Nathan");
        mainCamera = GameObject.Find("MainCamera");
        lifeTimer = lifeDuration;
        foreach (Transform child in transform){
            Boos.Add(child.gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(onFly){
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        foreach(GameObject child in Boos){
            child.transform.LookAt(mainCamera.transform);
            child.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        }
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0f){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Human"){
            
        }
        onFly = false;
        Destroy(gameObject);
    }
}
