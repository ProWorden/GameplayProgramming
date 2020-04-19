using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_coin : MonoBehaviour
{
    public player_coins playerCoins;
    public player_health playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("HIT!");
            playerCoins.addCoin();
            playerHealth.addHealth(1);
            Destroy(this.gameObject);
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
