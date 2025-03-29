using UnityEngine;
using UnityEngine.InputSystem;

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
        transform.position = objectToFollow.transform.position + new Vector3(0f, 3.6f, -6f);

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            mainCamera.transform.eulerAngles += new Vector3(0f, 30f, 0f);
        } else if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            mainCamera.transform.eulerAngles += new Vector3(0f, -30f, 0f);
        }
    }
}
