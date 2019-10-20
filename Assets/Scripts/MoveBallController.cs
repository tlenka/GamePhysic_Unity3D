using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallController : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * 0.1f;

    }
}
