using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    FixedJoint fixedJoint;
    Rigidbody rb;
    Rigidbody[] rigidbodies;
    Transform[] tr;

    void Start ()
    {
         
        rb = GetComponent<Rigidbody>();

        rigidbodies = GetComponentsInChildren<Rigidbody>();
        tr = GetComponentsInChildren<Transform>();

        foreach (var rigidbody in rigidbodies)
        {
            if (rigidbody != GetComponent<Rigidbody>())
            {
                rigidbody.isKinematic = false;
            }
        }

        foreach (var t in tr)
        {
            if (t != GetComponent<Transform>())
            {
                t.SetParent(null);
            }
        }

    }
	void Update ()
    {
        transform.Rotate(0, Time.deltaTime * 40.0f, 0);

        fixedJoint = GetComponent<FixedJoint>();
        if (fixedJoint == null)
        {
            rb.isKinematic = false;
            transform.Rotate(0, 0, 0);
        }
    }


}
