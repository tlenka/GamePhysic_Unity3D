using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {

    bool m_Started;
    public Transform center;
    public Transform player;
    public bool IsAttack;

    private bool ShouldRotate;
    private int RotationStep = 0;

    private void Awake()
    {
        m_Started = true;
        

    }
    void FixedUpdate()
    {

        

        // transform.position += Vector3.forward * 0.015f;
       
        if (CanMoveForward() && !ShouldRotate)
        {
            if (IsAttack)
            {
                transform.LookAt(player);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                transform.Translate(Vector3.forward * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime);

            }
        }
        else
        {
            

            if(RotationStep <= 30)
            {
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, transform.eulerAngles += new Vector3(0, 150f, 0), Time.deltaTime);
                RotationStep++;
            }
            else
            {
                ShouldRotate = false;
                RotationStep = 0;
                
            }
           
        }

    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
    //    if (m_Started)
    //        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
    //        Gizmos.DrawWireCube(center.position, transform.localScale /2);
    //}


    bool CanMoveForward()
    {
        var hitCollider = Physics.OverlapBox(center.position, transform.localScale / 2, Quaternion.identity);


        if (hitCollider.Length > 0)
        {
            return true;
        }
        else
        {
            ShouldRotate = true;
            return false;
        }

        
        
    }
}
    