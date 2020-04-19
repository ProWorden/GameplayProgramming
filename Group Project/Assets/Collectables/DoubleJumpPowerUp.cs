using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoubleJumpPowerUp : MonoBehaviour
{
    public GameObject DoubleJump;
    public float multiplier = 3f;
    public float duration = 10f;
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }

    }

   

    IEnumerator PickUp(Collider player)
    {
        Debug.Log("Double jump picked up!");
        Destroy(gameObject);
       
        Instantiate(DoubleJump, transform.position, transform.rotation);

        NewMovement3D GetDoubleJump = player.GetComponent<NewMovement3D>();
        

        




        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(duration);

        


     
        

    }


}

