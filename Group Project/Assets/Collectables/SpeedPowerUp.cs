using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public GameObject SpeedBoostEffect;
    //public float multiplier = 1.4f;
    public float duration = 5f;
    public NewMovement3D player;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
            player.speedBoost = true;
        }

    }

        IEnumerator PickUp(Collider player)
        {
            Debug.Log("Speed Boost picked up!");
            //NewMovement3D speed = player.GetComponent<NewMovement3D>();
            SpeedBoostEffect = Instantiate(SpeedBoostEffect, transform.position, transform.rotation);
       

            //speed.playerSpeed *= multiplier;
            Destroy(gameObject);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(duration);
            //speed.playerSpeed /= multiplier;


        }
    
   
}
