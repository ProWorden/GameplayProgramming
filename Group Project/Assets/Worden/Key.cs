using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
     public globalControl saveData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("hey");
            Debug.Log("HIT!");
            saveData.hasKey = true;
            Destroy(this.gameObject);
        }
    }

}
