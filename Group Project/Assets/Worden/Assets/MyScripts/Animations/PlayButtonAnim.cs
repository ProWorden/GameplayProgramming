using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonAnim : MonoBehaviour
{
    public Animation anim;
    public NewMovement3D playerScript;
    public float animTimer = 0;
    public bool buttonFinished = false;
    int buttonhits = 0;
    public Animator test;

    private void Start()
    {
       

        
    }
    void Update()
    {
        if(playerScript.hitSwitch)
        {

            animTimer += Time.deltaTime;
            if (animTimer > 1.33f)
            {
               // anim.Stop();
                animTimer = 1.33f;
                buttonFinished = true;
            }
            else if (animTimer > 0.33f)
            {
                // anim.Play();  
                test.SetBool("ButtonPressed", true);
            }

            
            
            
        }
        else
        {
            animTimer = 0;
        }

        
    }


}
