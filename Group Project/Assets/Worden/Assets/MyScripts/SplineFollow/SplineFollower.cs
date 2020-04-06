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
    public playerDetectionBack collision;
    public SplineTrackPos cameraSpline;
    public CharacterController cc;

    public newCamera freeCam;
    public SplineFollower splineCam;
    public SplineTrackPos SplinePos;
  


    public void OnEnable()
    {
        move.inSpline = true;

        if(collision.back == true)
        {
            distanceTravelled = 46.5f;
            cameraSpline.distanceTravelled = 33f;
        }
        else 
        {
            distanceTravelled = 3.5f;
            cameraSpline.distanceTravelled = 0f;
        }
    }

    void Update()
    {
        Vector3 midPlayer = new Vector3 (player.position.x, player.position.y + 1.3f, player.position.z);

       
       
        RaycastHit hit;

        if (Physics.Raycast(midPlayer, player.transform.TransformDirection(Vector3.forward), out hit, 1.0f))
        {
            distanceTravelled += 0;
            SplinePos.colliding = true;
        }
        else
        {
            distanceTravelled -= move.input.x * move.playerSpeed * Time.deltaTime;
            SplinePos.colliding = false;
        }
       
            
          //  print(distanceTravelled);
       
       Vector3 spline = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
       player.position = new Vector3(spline.x, player.position.y, spline.z);
       

        // transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled,endOfPathInstruction);


        //transform.rotation = startRot.rotation;
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        transform.rotation *= Quaternion.Euler(30, 90, 0);

        if (distanceTravelled > 50f || distanceTravelled < 0f)
        {
            collision.back = false;
            move.inSpline = false;
            freeCam.enabled = true;
            splineCam.enabled = false;
            SplinePos.enabled = false; 
        }
       
    }
}
