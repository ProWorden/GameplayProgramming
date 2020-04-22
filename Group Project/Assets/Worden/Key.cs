using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
     public Player_key keyScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("hey");
            Debug.Log("HIT!");
            keyScript.hasKey = true;
            Destroy(this.gameObject);
        }
    }

}
