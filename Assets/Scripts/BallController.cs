using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    bool m_Started;
    Vector3 movement;
    // Use this for initialization
    void Start()
    {
        m_Started = true;
        rb = GetComponent<Rigidbody>();
        //movement = new Vector3(1f, 0.0f, 0f);
        movement = Vector3.forward * 2;
        rb.AddForce(movement * speed);
    }

    void FixedUpdate()
    {
        // float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        
       



        Collider[] hitColliders = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z) + movement*0.8f, transform.localScale / 2);

        //int i = 0;
        ////Check when there is a new collider coming into contact with the box
        //while (i < hitColliders.Length)
        //{
        //    //Output all of the collider names
        //    Debug.Log("Hit : " + hitColliders[i].name);
        //    //Increase the number of Colliders in the array
        //    i++;
        //}

        if (hitColliders.Length == 0)
        {
            Debug.Log("ass");
            movement = new Vector3(2, 0, -2);
          //  rb.AddForce(movement * speed);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z) + movement*0.8f, transform.localScale/2);

        //Gizmos.DrawWireCube(transform.position, transform.localScale);

    }
}
