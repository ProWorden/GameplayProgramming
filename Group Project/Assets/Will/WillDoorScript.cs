using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillDoorScript : MonoBehaviour
{
    [SerializeField]
    private Transform openTransform;

    private Vector3 openPosition;
    private Vector3 closedPosition;

    private Vector3 targetPosition;

    [SerializeField]
    private bool startsOpen;
    private bool moveDoor = false;

    [SerializeField]
    private float speed = 5f;
    private readonly float tolerance = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        openPosition = openTransform.position;
        closedPosition = transform.position;

        targetPosition = openPosition;

        if(startsOpen)
        {
            transform.position = openPosition;
            targetPosition = closedPosition;
        }
        
    }

    public void ChangeMoveStatus()
    {
        moveDoor = !moveDoor;
    }

    void DoorMovement()
    {
        Vector3 heading = targetPosition - transform.position;
        transform.position += heading.normalized * speed * Time.deltaTime;

        if (heading.magnitude < tolerance)
        {
            transform.position = targetPosition;
            ChangeTargetLocation();
            ChangeMoveStatus();
        }
    }

    void ChangeTargetLocation()
    {
        if (targetPosition == openPosition)
        {
            targetPosition = closedPosition;
        }
        else if(targetPosition == closedPosition)
        {
            targetPosition = openPosition;
        }
        Debug.Log("closed: ");
        Debug.Log(closedPosition);
        Debug.Log("open: ");
        Debug.Log(openPosition);
        Debug.Log("current: ");
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveDoor)
        {
            if (transform.position != targetPosition)
            {
                DoorMovement();
            }
            /*else
            {
                ChangeTargetLocation();
            }*/
            
        }
    }
}
