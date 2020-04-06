using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch2 : MonoBehaviour
{
    public GameObject player;
    public NewMovement3D playerScript;
    public bool switchOn = false;
    Renderer render;
    bool startTimer = false;
    float timer = 0f;
    private void Start()
    {
        render = transform.GetComponent<Renderer>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetButtonDown("Fire1"))
        {
            startTimer = true;
            timer = 0f;
            switchOn = !switchOn;

        }




    }

    private void Update()
    {
        if (startTimer && timer <= 0.4f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.4f;

            if (!switchOn)
            {

                render.material.SetColor("_Color", Color.red);
            }
            else
            {

                render.material.SetColor("_Color", Color.green);
            }
        }

    }
}
