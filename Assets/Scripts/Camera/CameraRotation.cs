using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Camera mainCamera;

    public GameObject objectToFollow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxisRaw("Mouse X"));
    }
}
