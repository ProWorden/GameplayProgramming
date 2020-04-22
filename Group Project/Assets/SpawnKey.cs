using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public MeshRenderer render;
    public FactoryDoorOpen opening;
    float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        if(opening.openingDoor && timer <=1)
        {
            render.enabled = true;
            timer += Time.deltaTime;
        }
        else
        {
            render.enabled = false;
        }
    }
}
