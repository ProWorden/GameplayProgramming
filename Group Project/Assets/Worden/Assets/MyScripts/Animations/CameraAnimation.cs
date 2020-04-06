using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animation cameraAnim;
    public Animation fadeAnim;
    public NewMovement3D playerScript;
    public float animTimer = 0;
    public Camera mainCam;
    public Camera cutsceneCam;

    private void Start()
    {
        


    }
    void Update()
    {
        if (playerScript.hitSwitch)
        {
          
            animTimer += Time.deltaTime;
           if (animTimer > 6.83f)
            {
                fadeAnim.Stop();
                animTimer = 6.83f;
                
            }
            if(animTimer > 6.33f)
            {
                cameraAnim.Stop();

                cutsceneCam.enabled = false;
                mainCam.enabled = true;

                
            }
            else if (animTimer > 5.83f)
            {
                fadeAnim.Play();
            }
            else if (animTimer > 0)
            {
                mainCam.enabled = false;
                cutsceneCam.enabled = true;
                cameraAnim.Play();
            }




        }
        else
        {
            animTimer = 0;
            mainCam.enabled = true;
            cutsceneCam.enabled = false;
        }


    }

}
