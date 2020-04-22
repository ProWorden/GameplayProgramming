using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterDamage : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject save_location;

    bool save_him = false;

    private void OnTriggerStay(Collider other)
    {
        save_him = true;
    }

    private void LateUpdate()
    {
        if (save_him)
        {

            player.transform.position = save_location.transform.position;
            //player.GetComponent<player_health>().removeHealth();
            save_him = false;
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
