using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetectionBack : MonoBehaviour
{
    public newCamera freeCam;
    public SplineFollower splineCam;
    public SplineTrackPos SplinePos;
    public bool back = false;

   
    void OnTriggerEnter(Collider other)
    {
        print("hey");
        if (other.gameObject.tag == "Player")
        {
            back = true;
            freeCam.enabled = false;
            splineCam.enabled = true;
            SplinePos.enabled = true;
            

        }
    }
}
