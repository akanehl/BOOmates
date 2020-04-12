using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    //public GameObject bulletMag;
    private float rate = 1f;
    private float lastShot = 0f;
    public int loadBullets = 100;
    //private float reloadTime = 4f;
    //private AudioSource _AudioSource
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fire(){
        if(Time.time > rate + lastShot){
            loadBullets -= 1;
            //var _bulletsManagement = bulletMag.GetComponent<_BulletsManagement>();
            //_bulletsManagement.PopFromStack();
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = transform.position;
            bulletObject.transform.forward = transform.forward;
            lastShot = Time.time;
        }
    }
}
