using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{
    public NewMovement3D playerScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (playerScript.jumped && playerScript.velocity.y >0)
        {
              playerScript.velocity.y = -playerScript.velocity.y * 0.2f;
            playerScript.headCollision = true;
        }
    }

    private void Update()
    {
        if(playerScript.grounded)
        {
            playerScript.headCollision = false;
        }
    }
}
