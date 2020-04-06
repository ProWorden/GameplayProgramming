using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostCollectable : MonoBehaviour
{

    public GameObject pickupEffect = null;
    public NewMovement3D player;
    public GameObject SpeedTrail = null;
    public Transform character;
    private GameObject instantiatedObj;
    
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {

            player.speedBoost = true;

           pickupEffect = Instantiate(pickupEffect, transform.position, transform.rotation);
            SpeedTrail =  Instantiate(SpeedTrail, character.transform.position, character.transform.rotation, character);

            Destroy(SpeedTrail, 10.0f);

            Destroy(pickupEffect, 2.0f);

            Destroy(transform.parent.gameObject);

        }
    }

  
}

