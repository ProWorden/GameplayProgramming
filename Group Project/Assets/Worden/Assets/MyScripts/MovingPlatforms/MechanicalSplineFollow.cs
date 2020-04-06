using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class MechanicalSplineFollow : MonoBehaviour
{




    public PathCreator pathCreator;
    public float distanceTravelled;
    public EndOfPathInstruction endOfPathInstruction;
    public float moveSpeed = 3;
    public Transform player;
    bool onPlatform = false;
    bool jumpingOnPlatform = false;
    bool landed = false;
    public CharacterController cc;
    public float timer = 5f;
    public Vector3 platformVelocity;
    public bool startTimer = false;
    bool startPauseTimer = true;
    public float pauseTimer = 0f;
    public PlatformSwitch2 trigger;
    


    private void LateUpdate()
    {
        if(trigger.switchOn)
        {
            if (pauseTimer > 5.0f && !startTimer)
            {
                timer = 0;
                startTimer = true;
                startPauseTimer = false;
            }

            if (startTimer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                pauseTimer += Time.deltaTime;
                distanceTravelled += moveSpeed * Time.deltaTime;
            }


            if (timer > 2.0f && !startPauseTimer)
            {
                pauseTimer = 0;
                startPauseTimer = true;
                startTimer = false;
            }

        }

    }

    void Update()
    {

        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        Vector3 platRot = new Vector3(0f, pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction).y, 0f);
        transform.rotation = Quaternion.Euler(platRot);

   

        

        if (onPlatform)
        {

            if (Input.GetAxis("Jump") > 0)
            {
                jumpingOnPlatform = true;

            }


        }


        if (jumpingOnPlatform)
        {
            Vector3 platformVelocity = pathCreator.path.GetDirectionAtDistance(distanceTravelled);

            if(startPauseTimer && trigger.switchOn)
            {
                player.GetComponent<NewMovement3D>().velocity += new Vector3(platformVelocity.x * 7 / 6, 0, platformVelocity.z * 7 / 6);
            }

           

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

