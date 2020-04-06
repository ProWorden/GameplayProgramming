using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController controller;
    private Animator animator;
    public float moveSpeed;
    private Vector3 moveDirection;
    public float rotationSensitivity = 150.0f;
    float characterRotation;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);

        controller.Move(moveDirection * Time.deltaTime);

        animator.SetBool("Moving", true);
        animator.SetFloat("Velocity X", Input.GetAxis("Horizontal") * moveSpeed);
        animator.SetFloat("Velocity Z", Input.GetAxis("Vertical") * moveSpeed);

        float stickInput = Input.GetAxis("RightStickHorizontal");
        float mouseInput = Input.GetAxis("Mouse X");

        float totalInput = stickInput + mouseInput;
        characterRotation += totalInput * rotationSensitivity * Time.deltaTime;
        Quaternion localRotation = Quaternion.Euler(transform.rotation.x, characterRotation, transform.rotation.z);
        transform.rotation = localRotation;

    }

}
