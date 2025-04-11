using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public GameObject leftDoor, rightDoor;

    public Vector3 openPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //leftDoor.transform.position -= openPosition;
        //rightDoor.transform.position += openPosition;

        OpenDoors();
    }

    private void OnTriggerExit(Collider other)
    {
        //leftDoor.transform.position += openPosition;
        //rightDoor.transform.position -= openPosition;

        CloseDoors();
    }

    void OpenDoors()
    {
        Vector3 openedLeftDoorPosition = leftDoor.transform.position -= openPosition;
        float left = leftDoor.transform.position.x;
        left = Mathf.Lerp(left, openedLeftDoorPosition.x, 10f);

        Vector3 openedRightDoorPosition = rightDoor.transform.position += openPosition;
        float right = rightDoor.transform.position.x;
        right = Mathf.Lerp(right, openedLeftDoorPosition.x, 10f);
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
