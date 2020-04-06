using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlatformSplineFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;
    public float moveSpeed = 5;
    public Transform player;
    bool onPlatform = false;
    bool jumpingOnPlatform = false;
    bool landed = false;
    public CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       


        Vector3 platRot = new Vector3(0f, pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction).y, 0f);
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        transform.rotation =  Quaternion.Euler(platRot);
        
        distanceTravelled += moveSpeed * Time.deltaTime;
       

        if(onPlatform)
        {
           

           // Vector3 platformVelocity = pathCreator.path.GetDirectionAtDistance(distanceTravelled);
          //  player.GetComponent<NewMovement3D>().velocity += new Vector3(platformVelocity.x *0.0f, 0, platformVelocity.z *0.00f);
           
            if (Input.GetAxis("Jump") > 0)
            {
                jumpingOnPlatform = true;
                
            }


        }
     

        if(jumpingOnPlatform)
        {
            Vector3 platformVelocity = pathCreator.path.GetDirectionAtDistance(distanceTravelled);
            player.GetComponent<NewMovement3D>().velocity += new Vector3(platformVelocity.x * 0.7f, 0, platformVelocity.z * 0.7f);

            if (cc.isGrounded)
            {
                jumpingOnPlatform = false;
            }
        }

      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetParent(this.transform);
            onPlatform = true;
           

        }
    }

   void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {     
            
            onPlatform = false;
            player.SetParent(null);
        }
    }


    
}
