using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {

    Vector3 startPos;
    bool shouldStay;
    int elevatorMove;

    private void Awake()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        switch (elevatorMove)
        {

            case 1:
                GoUp();
                break;
            case -1:
                GoDown();
                break;
            default:
                break;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Ragdoll")
        {
            elevatorMove = 1;
            other.transform.SetParent(gameObject.transform);
            shouldStay = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.name == "Ragdoll")
        {
            other.transform.SetParent(null);
            shouldStay = false;
        }
        elevatorMove = -1;

    }

    void GoUp()
    {
        transform.position = Vector3.Lerp(transform.position, startPos + Vector3.up * 10f, Time.deltaTime * 0.1f);
    }

    void GoDown()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * 0.2f);
    }

    private void OnCollisionStay(Collision collision)
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2);
        int i = 0;

        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Floor")
            {
                if (shouldStay)
                {
                    elevatorMove = 0;
                }
                else
                {
                    elevatorMove = -1;
                }
            }
            i++;
        }
    }

   
}

