using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public GameObject leftDoor, rightDoor;

    public GameObject singleDoorClosed, singleDoorOpened;

    public Vector3 closedStatePositionLeft, closedStatePositionRight;

    public Vector3 openPosition;

    public Transform singleDoorClosedState, singleDoorOpenedState;

    public bool shouldOpenDoors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closedStatePositionLeft = leftDoor.transform.position;
        closedStatePositionRight = rightDoor.transform.position;

        singleDoorClosedState = singleDoorClosed.transform;
        singleDoorOpenedState = singleDoorOpened.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldOpenDoors)
        {
            OpenDoors();
            OpenDoor();
        }
        else
        {
            CloseDoors();
            CloseDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //leftDoor.transform.position -= openPosition;
        //rightDoor.transform.position += openPosition;

        //OpenDoors();

        shouldOpenDoors = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //leftDoor.transform.position += openPosition;
        //rightDoor.transform.position -= openPosition;

        //CloseDoors();

        shouldOpenDoors = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        shouldOpenDoors = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        shouldOpenDoors = false;
    }

    void OpenDoors()
    {
        //Vector3 openedLeftDoorPosition = leftDoor.transform.position -= openPosition;
        //float left = leftDoor.transform.position.x;
        //left = Mathf.Lerp(left, openedLeftDoorPosition.x, 0.1f);

        //Vector3 openedRightDoorPosition = rightDoor.transform.position += openPosition;
        //float right = rightDoor.transform.position.x;
        //right = Mathf.Lerp(right, openedLeftDoorPosition.x, 0.1f);

        leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, -openPosition - new Vector3(0f, -leftDoor.transform.position.y, 0f), Time.deltaTime);
        rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, openPosition + new Vector3(2f, rightDoor.transform.position.y, 0f), Time.deltaTime);
    }

    void CloseDoors()
    {
        //Vector3 closedLeftDoorPosition = leftDoor.transform.position += openPosition;
        //float left = leftDoor.transform.position.x;
        //left = Mathf.Lerp(left, closedLeftDoorPosition.x, 1f);

        //Vector3 openedRightDoorPosition = rightDoor.transform.position -= openPosition;
        //float right = rightDoor.transform.position.x;
        //right = Mathf.Lerp(right, closedLeftDoorPosition.x, 1f);

        leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, closedStatePositionLeft, Time.deltaTime);
        rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, closedStatePositionRight, Time.deltaTime);

    }

    void OpenDoor()
    {
        singleDoorClosedState.position = Vector3.Lerp(singleDoorClosedState.position, singleDoorOpenedState.position, Time.deltaTime);
        singleDoorClosedState.rotation = Quaternion.Lerp(singleDoorClosedState.rotation, singleDoorOpenedState.rotation, Time.deltaTime);
    }

    void CloseDoor()
    {
        singleDoorClosedState.position = Vector3.Lerp(singleDoorOpenedState.position, singleDoorClosedState.position, Time.deltaTime);
        singleDoorClosedState.rotation = Quaternion.Lerp(singleDoorOpenedState.rotation, singleDoorClosedState.rotation, Time.deltaTime);
    }
}
