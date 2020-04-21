using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    [SerializeField]
    Collider player;
    [SerializeField]
    GameObject sceneLoader;
    [SerializeField]
    string scene_to_load;
    [SerializeField]
    string spawn_to_use;

    private void OnTriggerEnter(Collider other)
    {
        if(other == player)
        {
            sceneLoader.GetComponent<SceneLoaderScript>().LoadScene(scene_to_load);
            globalControl.Instance.spawn_location = spawn_to_use;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
