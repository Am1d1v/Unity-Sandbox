using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public GameObject leftDoor, rightDoor;

    public Vector3 openPosition;

    public bool shouldOpenDoors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldOpenDoors)
        {
            leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, -openPosition - new Vector3(0f, -leftDoor.transform.position.y, 0f), Time.deltaTime);
            rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, openPosition + new Vector3(2f, rightDoor.transform.position.y, 0f), Time.deltaTime);
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

    void OpenDoors()
    {
        Vector3 openedLeftDoorPosition = leftDoor.transform.position -= openPosition;
        float left = leftDoor.transform.position.x;
        left = Mathf.Lerp(left, openedLeftDoorPosition.x, 0.1f);

        Vector3 openedRightDoorPosition = rightDoor.transform.position += openPosition;
        float right = rightDoor.transform.position.x;
        right = Mathf.Lerp(right, openedLeftDoorPosition.x, 0.1f);
    }

    void CloseDoors()
    {
        Vector3 closedLeftDoorPosition = leftDoor.transform.position += openPosition;
        float left = leftDoor.transform.position.x;
        left = Mathf.Lerp(left, closedLeftDoorPosition.x, 1f);

        Vector3 openedRightDoorPosition = rightDoor.transform.position -= openPosition;
        float right = rightDoor.transform.position.x;
        right = Mathf.Lerp(right, closedLeftDoorPosition.x, 1f);
    }
}
