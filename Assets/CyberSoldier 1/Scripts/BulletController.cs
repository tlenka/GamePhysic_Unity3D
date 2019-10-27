using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.AddComponent<FixedJoint>();
            var fixedJoint = GetComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.rigidbody;
            rb.useGravity = true;
            transform.SetParent(collision.transform);
        }

    }


}
