using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    Vector3 startPos;
    bool shouldGoUp;


    private void Awake()
    {
        startPos = transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
        shouldGoUp = true;
    }

    private void OnTriggerExit(Collider other)
    {
        shouldGoUp = false;
    }


    void Update()
    {
        if (shouldGoUp)
            GoUp();
        else
            GoDown();
    }

    void GoUp()
    {
        transform.position = Vector3.Lerp(transform.position, startPos + Vector3.up * 10f, Time.deltaTime * 0.1f);
    }

    void GoDown()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * 0.1f);
    }

}
