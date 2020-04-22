using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win_game : MonoBehaviour
{

    [SerializeField]
    GameObject sceneLoader;
    [SerializeField]
    string scene_to_load;
    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            sceneLoader.GetComponent<SceneLoaderScript>().LoadScene(scene_to_load);

        }
    }
}
