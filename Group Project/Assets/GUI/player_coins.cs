using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_coins : MonoBehaviour
{

    public int coins;
    public Text coin_count;

    // Start is called before the first frame update
    void Start()
    {
        
        coin_count.text = "" + coins;
    }

    // Update is called once per frame
    void Update()
    {
        coin_count.text = "" + coins;
    }

    public void addCoin()
    {
        coins++;
    }
}
