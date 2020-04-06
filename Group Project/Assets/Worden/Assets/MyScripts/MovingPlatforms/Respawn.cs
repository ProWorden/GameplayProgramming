using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform player;
    public GameObject TPLocation;
   void OnTriggerEnter(Collider other)
    {
        print("bruh");
        if(other.CompareTag("Player"))
        {
            player.transform.position = TPLocation.transform.position;
            player.transform.rotation = TPLocation.transform.rotation;
        }
       
    }


}
