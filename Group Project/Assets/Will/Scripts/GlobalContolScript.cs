using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContolScript : MonoBehaviour
{
    public static GlobalContolScript Instance;
    /*ensures there is only one instance of this script running and will store data 
     * that needs to be carried over bewtween scenes e.g.*/
     //player health 
     //enemy health 
     //powerups used 
     //timers
    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
