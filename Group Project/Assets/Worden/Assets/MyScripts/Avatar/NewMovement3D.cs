using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement3D : MonoBehaviour
{
    ContactPoint slopeAngle;

    //object
    public Transform cam;
    CharacterController cc;
    Animator anim;
    public Transform player;
    public SpeedBoostCollectable speedPickup;
    //input
     public Vector2 input;

    //combat
    public float attackTimer = 0f;
    public int attackCounter = 0;
    bool kicked = false;
    bool jumpKicked = false;

    public SphereCollider LeftHand;
    public SphereCollider RightHand;
    public SphereCollider LeftFoot;
    public SphereCollider RightFoot;


    public bool hitPlayer = false;
    Renderer render;
    public Material mat1;
    public Material mat2;
    public Transform enemy;

    CapsuleCollider cap;
   
    public float hitBack = 0f;
    float delayTimer = 0f;

    //camera
    Vector3 camF;
     Vector3 camR;

    

    //Physics
    Vector3 intent;
   public Vector3 velocityXZ;
    public Vector3 velocity;
    public float playerSpeed = 8;
   public float playerAcceleration = 11;
    float turnSpeed = 5;
    float minTurnSpeed = 15;
    float maxTurnSpeed = 40;
    float jumpTimer = 0.0f;
    public bool inSpline = true;

    public bool headCollision = false;

    //gravity
   public float gravityMagnitude = -9.81f;
    public bool grounded = false;
    float terminalVelocity = -30f;

    //jump
    public float jumpForce = 10f;
    public float jumpForceTwo = 10f;
   public float airTimer = 0.0f;
   public bool jumped = false;
    int numJumps = 1;
    int jumpCounter = 0;
    float DoubleJumpTimer = 0f;
     bool doubleJumped = false;

    //powerups
   public bool doubleJump = false;
   public bool speedBoost = false;
   float speedTimer = 0;
    float jumpPickupTimer = 0;

    float ts;

    //Switch
    public bool hitSwitch = false;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        render = GetComponentInChildren<Renderer>();
        cap = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit you");
            
            enemy = other.transform;

           

        }
    }
 
    void Update()
    {
        hitButton();
        getInput();
        calculateCameraPosition();
        calculateGround();
        movement();
        addGravity();
        jump();
        attack();
        jumpCollision();
        SpeedPickup();
        JumpPickup();


        if(hitPlayer)
        {
            TakeDamage();
        }
       
        
        cc.Move(velocity * Time.deltaTime);
         
    }

    void getInput()
    {
        if (inSpline)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), 0);
            minTurnSpeed = 100;
            maxTurnSpeed = 100;

        }
        else
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            minTurnSpeed = 15;
            maxTurnSpeed = 40;
        }

        input = Vector2.ClampMagnitude(input, 1);
    }
    void calculateCameraPosition()
    {

        camF = cam.forward;
        camR = cam.right;

        //ignore angle of camera for movement
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;


    }
    void movement()
    {
        if (!hitSwitch)
        {
            //moving relative to camera direction

            intent = camF * input.y + camR * input.x;

            ts = velocity.magnitude / playerSpeed;
            turnSpeed = Mathf.Lerp(maxTurnSpeed, minTurnSpeed, ts);

            if (input.magnitude > 0)
            {
                anim.SetFloat("Velocity", playerSpeed);
                anim.SetBool("Moving", true);


                Quaternion rot = Quaternion.LookRotation(intent);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, turnSpeed * Time.deltaTime);


            }
            else
            {
                anim.SetFloat("Velocity", 0);
                anim.SetBool("Moving", false);
            }

            velocityXZ = velocity;
            velocityXZ.y = 0;
            velocityXZ = Vector3.Lerp(velocityXZ, transform.forward * input.magnitude * playerSpeed, playerAcceleration * Time.deltaTime);
            velocity = new Vector3(velocityXZ.x, velocity.y, velocityXZ.z);
        }

    }

    void addGravity()
    {
        if (grounded)
        {
            velocity.y = -5f;

        }
        else
        {
            velocity.y += gravityMagnitude * Time.deltaTime;
            velocity.y = Mathf.Clamp(velocity.y, terminalVelocity, 20);
        }

    }

    void calculateGround()
    {


        if (cc.isGrounded)
        {




            grounded = true;
            jumped = false;

            if (airTimer > 0.3)
            {
                airTimer = 0;

            }
            anim.SetBool("Landed", true);
            anim.SetFloat("AirTimer", airTimer);
            anim.SetBool("Jumping", false);



        }
        else
        {

            grounded = false;

            airTimer += Time.deltaTime;
            anim.SetFloat("AirTimer", airTimer);
            anim.SetBool("Landed", false);

            if (airTimer > 0.3)
            {

                anim.SetBool("Landed", false);
            }
        }
    }

    void jump()
    {
        if (grounded)
        {
            jumpCounter = 0;
            anim.SetBool("DoubleJumped", false);
        }

        if (doubleJumped)
        {
            DoubleJumpTimer += Time.deltaTime;
            anim.SetFloat("DJTimer", DoubleJumpTimer);
        }

        if (DoubleJumpTimer > 0.75)
        {
            DoubleJumpTimer = 0f;
            doubleJumped = false;
            anim.SetBool("DoubleJumped", false);

        }


        if (jumpCounter < numJumps)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumped = true;

                if (jumpCounter == 0)
                {
                    velocity.y = jumpForce;
                }
                else
                {
                    velocity.y = jumpForceTwo;
                    anim.SetBool("DoubleJumped", true);
                    doubleJumped = true;
                }

                jumpCounter++;


            }


        }

        if (cc.collisionFlags == CollisionFlags.Above)
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("DoubleJumped", false);
            jumpTimer = 0f;
            jumped = false;
        }

        if (jumped)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer > 0.05f)
            {
                anim.SetBool("Jumping", true);
            }
        }

    }

    void attack()
    {
        if (Input.GetButtonDown("Fire1") && !hitSwitch)
        {

            if (!grounded)
            {
                if (jumpKicked == false)
                {
                    attackTimer -= 0.3f;
                }

                anim.SetBool("JumpKicked", true);
                RightFoot.enabled = true;
                cap.enabled = false;
                jumpKicked = true;

            }
            else if (input.magnitude == 0)
            {

                attackCounter++;

                if (attackCounter == 1)
                {
                    LeftHand.enabled = true;
                    RightHand.enabled = false;
                }
                else if (attackCounter == 2)
                {
                    RightHand.enabled = true;
                    LeftHand.enabled = false;
                }
                else if (attackCounter >= 3)
                {
                    LeftHand.enabled = true;
                    RightHand.enabled = false;
                }
                else if (attackCounter == 0)
                {
                    LeftHand.enabled = false;
                    RightHand.enabled = false;
                }


                anim.SetInteger("AttackCounter", attackCounter);

                if (attackCounter < 3)
                {

                    attackTimer -= 0.45f;
                }




            }
            else
            {
                if (kicked == false)
                {
                    attackTimer -= 0.8f;
                }

                kicked = true;
                cap.enabled = false;
                LeftFoot.enabled = true;
                anim.SetBool("Kicked", true);

            }



        }

        if (attackCounter > 0 || kicked || jumpKicked)
        {
            attackTimer += Time.deltaTime;


        }

        if (attackTimer >= 0)
        {
            attackTimer = 0;
            attackCounter = 0;

            LeftHand.enabled = false;
            RightHand.enabled = false;

            cap.enabled = true;

            anim.SetInteger("AttackCounter", attackCounter);

            kicked = false;
            LeftFoot.enabled = false;
            anim.SetBool("Kicked", false);

            jumpKicked = false;
            RightFoot.enabled = false;
            anim.SetBool("JumpKicked", false);

        }





    }

    void jumpCollision()
    {
        if (cc.collisionFlags == CollisionFlags.Above)
        {

            print("Touching Ceiling!");
            if (!grounded && !Input.GetButtonDown("Jump") && velocity.y > 0)

            {

                velocity.y = -velocity.y * 0.2f;

            }


        }
    }

    void SpeedPickup()
    {
        if (speedBoost)
        {
            playerSpeed = 12;
            speedTimer += Time.deltaTime;
        }

        if (speedTimer > 10.0f)
        {
            playerSpeed = 8;
            speedTimer = 0;
            speedBoost = false;

        }
    }

    void JumpPickup()
    {
        if (doubleJump)
        {
            numJumps = 2;

            jumpPickupTimer += Time.deltaTime;
            print(jumpPickupTimer);
        }

        if (jumpPickupTimer > 10.0f)
        {
            numJumps = 1;
            jumpPickupTimer = 0.0f;
            doubleJump = false;

        }

    }

    void hitButton()
    {
        if (hitSwitch)
        {

            cc.enabled = false;
            anim.SetBool("HitSwitch", true);
        }
        else
        {
            cc.enabled = true;
            anim.SetBool("HitSwitch", false);

        }
    }

    void TakeDamage()
    {



        hitBack += 3 * Time.deltaTime;
        if (enemy != null)
        {
            print("hello");
            transform.position = Vector3.Lerp(transform.position, transform.position + (0.5f * enemy.transform.forward), hitBack);
        }

        render.material = mat2;
        if (hitBack >= 0.5)
        {
            render.material = mat1;
        }


        if (hitBack >= 1)
        {
            hitBack = 1;
            hitPlayer = false;


        }
    }

}