using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SplineTrackPos : MonoBehaviour
{
    public PathCreator pathCreator;
   
    public float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;


    public Transform player;
    public newCamera cam;
    public NewMovement3D move;
    public SplineFollower follower;
    public bool colliding = false;





    void Update()
    {
      


        

       // print(distanceTravelled);

       

        if(!colliding)
        {
            if (follower.distanceTravelled >= 25 && follower.distanceTravelled <= 33)
            {
                distanceTravelled -= move.input.x * move.playerSpeed * 2f * Time.deltaTime;
            }
            else
            {
                distanceTravelled -= move.input.x * move.playerSpeed * 0.5f * Time.deltaTime;
            }

        }







        Vector3 getXZSpline = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        transform.position = new Vector3(getXZSpline.x, player.position.y + 8, getXZSpline.z);











    }
}
