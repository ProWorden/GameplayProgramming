using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSpawnLocation : MonoBehaviour
{
    private GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find(globalControl.Instance.spawn_location) != null)
        {
            spawn = GameObject.Find(globalControl.Instance.spawn_location);
        }
        transform.position = spawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
