using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour {

    public float bulletVelocity = 3.0f;
    
        
   
    // Use this for initialization
    void Start () {
        //Debug.Log(bullet);
        
    }
	
	// Update is called once per frame
	void Update () {
        var bulletRb = GetComponent<Rigidbody>();
        bulletRb.AddForce(Vector3.forward * bulletVelocity, ForceMode.Impulse);
        Debug.Log(bulletRb);
    }
}
