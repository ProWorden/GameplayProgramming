using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalControl : MonoBehaviour
{
    public static globalControl Instance;

    public int numberOfHearts;
    public int playerHealth;
    public int coins;
    public bool hasKey;

    // doors?

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StoreDate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
