using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    // Start is called before the first frame update
    void Start()
    {
        health = globalControl.Instance.playerHealth;
        numOfHearts = globalControl.Instance.numberOfHearts;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown( KeyCode.Backspace))
        {
            removeHealth();
        }

        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for(int i =0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }

            if( i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void addHealth(int health_to_add)
    {
        health += health_to_add;
    }

    public void removeHealth()
    {
        health--;
    }

    private void OnDestroy()
    {
        globalControl.Instance.playerHealth = health;
        globalControl.Instance.numberOfHearts = numOfHearts;
    }
}
