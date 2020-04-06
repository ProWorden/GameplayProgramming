using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetection : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public NewMovement3D playerScript;
    int numHits = 0;
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            if (Input.GetButtonDown("Fire1") && numHits == 0)
            {
                playerScript.hitSwitch = true;
                numHits++;
                other.transform.position = target.position;
                other.transform.rotation = target.rotation;
            }
        }
     
       

   
    }
   
}
