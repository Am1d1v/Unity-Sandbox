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
        leftDoor.transform.position -= openPosition;
        rightDoor.transform.position += openPosition;
    }

    private void OnTriggerExit(Collider other)
    {
        leftDoor.transform.position += openPosition;
        rightDoor.transform.position -= openPosition;
    }
}
