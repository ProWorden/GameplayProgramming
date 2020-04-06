using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    public newCamera freeCam;
    public SplineFollower splineCam;
    public SplineTrackPos SplinePos;

   
    void OnTriggerEnter(Collider other)
    {
        print("hey");
        if (other.gameObject.tag == "Player")
        {
            freeCam.enabled = false;
            splineCam.enabled = true;
            SplinePos.enabled = true;


        }
    }



}
