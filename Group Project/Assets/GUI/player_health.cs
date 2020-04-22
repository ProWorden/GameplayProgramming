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

    [SerializeField]
    GameObject sceneLoader;
    [SerializeField]
    string scene_to_load;

    // Start is called before the first frame update
    void Start()
    {
        health = globalControl.Instance.playerHealth;
        numOfHearts = globalControl.Instance.numberOfHearts;
    }

    // Update is called once per frame
    void Update()
    {

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

        checkDeath();
    }

    public void addHealth(int health_to_add)
    {
        health += health_to_add;
    }

    public void removeHealth()
    {
        health--;
    }

    public void checkDeath()
    {
        if (health <= 0)
        {

            sceneLoader.GetComponent<SceneLoaderScript>().LoadScene(scene_to_load);

        }
    }

    private void OnDestroy()
    {
        globalControl.Instance.numberOfHearts = numOfHearts;
        globalControl.Instance.playerHealth = health;
    }
}
