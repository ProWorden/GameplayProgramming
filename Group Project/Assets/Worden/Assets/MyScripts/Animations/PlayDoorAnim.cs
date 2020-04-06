using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDoorAnim : MonoBehaviour
{
   // public Animation anim;
    public PlayButtonAnim buttonScript;
    public float animTimer = 0;
    public NewMovement3D player;
    public Animator test;
    public GameObject door;
    private void Start()
    {



    }
    void Update()
    {
        if (buttonScript.buttonFinished)
        {

            this.animTimer += Time.deltaTime;
            if (this.animTimer > 5)
            {
                player.hitSwitch = false;
                animTimer = 5;
                buttonScript.buttonFinished = false;
            }
            else if (this.animTimer > 4f)
            {
              //  anim.Stop();

            }
            else if (this.animTimer > 2)
            {
                //  anim.Play();
                 test.SetBool("UnlockDoor", true);
               
            }




        }
        else
        {
            animTimer = 0;
        }


    }

}
