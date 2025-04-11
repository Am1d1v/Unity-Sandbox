using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public GameObject leftDoor, rightDoor;

    public Transform closedPosition, openedPosition;

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
        Debug.Log("Open");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Close");
    }
}
