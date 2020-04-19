using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineCamera2 : MonoBehaviour
{
    public Transform player;
    public NewMovement3D script;
    
   

    private void OnEnable()
    {
        script.inSpline = true;
    }
  
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + new Vector3(20, 2, 0);
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }
}
