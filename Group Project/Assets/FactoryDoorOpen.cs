using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryDoorOpen : MonoBehaviour
{
    
    public Player_key player_key_scr;
    float timer = 0;
   public bool openingDoor = false;
    public door door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && player_key_scr.hasKey)
        {
           
            print("should open");
            openingDoor = true;
            
        }
        
    }

    private void Update()
    {
        if(openingDoor)
        {
            door.removeDoor();
        }
    }


}
