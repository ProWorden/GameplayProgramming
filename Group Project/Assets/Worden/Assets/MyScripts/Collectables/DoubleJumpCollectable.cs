using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpCollectable : MonoBehaviour
{
    public GameObject pickupEffect = null;
    public NewMovement3D player;
    public GameObject JumpTrail = null;
    public Transform character;
  


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {

            player.doubleJump = true;

            pickupEffect = Instantiate(pickupEffect, transform.position, transform.rotation);
            JumpTrail = Instantiate(JumpTrail, character.transform.position, character.transform.rotation, character);

            Destroy(JumpTrail, 10.0f);

            Destroy(pickupEffect, 2.0f);

            Destroy(transform.parent.gameObject);

        }
    }

}
