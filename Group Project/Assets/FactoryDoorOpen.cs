using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryDoorOpen : MonoBehaviour
{
    public Animation anim;
    public globalControl GC;
    float timer = 0;
    bool openingDoor = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && GC.hasKey)
        {
            anim.Play();

            openingDoor = true;
            
        }
    }

    private void Update()
    {
        if(openingDoor&& timer <=1)
        {
            timer += Time.deltaTime;
            
        }
        else
        {
            anim.Stop();
        }
    }
}
