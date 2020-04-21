using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch2 : MonoBehaviour
{
    public GameObject player;

    public Camera playerCam;
    public Camera cutscenceCam;

    public Barrier barrier;
    public NewMovement3D playerScript;
    public bool switchOn = false;
    Renderer render;
    bool startTimer = false;
    bool playCutscene = false;
    float timer = 0f;
    bool done = false;

    public float barrierTimer = 0;

    private void Start()
    {
        render = transform.GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.red);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetButtonDown("Fire1"))
        {
            startTimer = true;
            timer = 0f;
            switchOn = true;

        }




    }

    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;

            if (timer >= 0.4f && !done)
            {


                if (switchOn)
                {
                    render.material.SetColor("_Color", Color.green);
                    playerScript.enabled = false;

                }
             

                if (timer >= 0.8)
                {
                    timer = 0.8f;
                    playCutscene = true;
                }
            }
        }

    


        if(playCutscene && !done)
        {
            
            playerCam.enabled = false;
            cutscenceCam.enabled = true;

            barrier.removeBarrier();

            if(barrierTimer >= 2.5)
            {
                playerScript.enabled = true;
                playerCam.enabled = true;
                cutscenceCam.enabled = false;
                done = true;
            }
            else
            {
                barrierTimer += Time.deltaTime;
            }

        }
    }

 
}
