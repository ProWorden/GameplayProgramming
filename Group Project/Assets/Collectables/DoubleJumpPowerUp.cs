using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoubleJumpPowerUp : MonoBehaviour
{
    public GameObject DoubleJump;
    public float multiplier = 3f;
    public float duration = 10f;
    public NewMovement3D player;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
            player.doubleJump = true;
        }

    }

   

    IEnumerator PickUp(Collider player)
    {
        Debug.Log("Double jump picked up!");
        
       
        DoubleJump = Instantiate(DoubleJump, transform.position, transform.rotation);

        NewMovement3D GetDoubleJump = player.GetComponent<NewMovement3D>();

        Destroy(gameObject);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(duration);

        


     
        

    }


}

