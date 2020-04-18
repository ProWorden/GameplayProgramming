using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SplineFollower : MonoBehaviour
{
    public PathCreator pathCreator;
  
   public  float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;
 
    public Transform player;
    public newCamera cam;
    public NewMovement3D move;
    //public playerDetectionBack collision;
    public CharacterController cc;

    public newCamera freeCam;
    public SplineFollower splineCam;
    public SplineTrackPos SplinePos;
    public Animator anim;


    public void OnEnable()
    {
        move.inSpline = true;

       
        distanceTravelled = 0f;
    }

    void Update()
    {
        Vector3 midPlayer = new Vector3 (player.position.x, player.position.y + 1.3f, player.position.z);

         RaycastHit hit;

         if (Physics.Raycast(midPlayer, player.transform.TransformDirection(Vector3.forward), out hit, 1))
         {
             distanceTravelled += 0;
         //    transform.position = player.localPosition + new Vector3(20, 2, 0);
            print("colliding");
            SplinePos.colliding = true;
         }
        else
        {
            distanceTravelled += move.input.x * move.playerSpeed * Time.deltaTime;
            SplinePos.colliding = false;
        }
         
         
           
         
        


        transform.position = player.localPosition + new Vector3(20, 2, 0);
        //print(distanceTravelled);

        Vector3 spline = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        player.position = new Vector3(spline.x, player.position.y, spline.z);


       


        //camera rotation
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        transform.rotation *= Quaternion.Euler(0, -90, 0);

        //camera position

      
        

        
       
       
   

        //when leaving spline area
        /*  collision.back = false;
                move.inSpline = false;
                freeCam.enabled = true;
                splineCam.enabled = false;
                SplinePos.enabled = false;
                print("left spline boundaries");
                */
    }
}
