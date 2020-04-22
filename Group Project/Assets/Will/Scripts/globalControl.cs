using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalControl : MonoBehaviour
{
    public player_health player_hp_scr;
    public player_coins player_coin_scr;
    public Player_key player_key_scr;

    public static globalControl Instance;

    public int numberOfHearts;
    public int playerHealth;
    public int coins;

    public bool hasKey;
    public bool door_1;
    public bool door_2;

    public string spawn_location;
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

        player_hp_scr.numOfHearts = numberOfHearts;
        player_hp_scr.health = playerHealth;
        player_coin_scr.coins = coins;
        player_key_scr.hasKey = hasKey;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfHearts = player_hp_scr.numOfHearts;
        playerHealth = player_hp_scr.health;

        coins = player_coin_scr.coins;
    }
}
