using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillSwitchScript : MonoBehaviour
{
    private Renderer render;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    Transform switchPressLocation;
    private Transform switchResetLocation;

    [SerializeField]
    Collider playerCollider;

    [SerializeField]
    GameObject targetObject;

    private bool inRange = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == playerCollider)
        {
            inRange = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (targetObject.GetComponent<WillDoorScript>() != null)
            {
                targetObject.GetComponent<WillDoorScript>().ChangeMoveStatus();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        switchResetLocation = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
