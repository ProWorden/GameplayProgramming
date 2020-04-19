using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_trigger_script : MonoBehaviour
{

    public movingPlatformScript platform;
    private void OnTriggerEnter(Collider other)
    {
        if(platform.current_target == platform.points[0])
        {
            platform.NextPlatform();
        }
        
    }
}
