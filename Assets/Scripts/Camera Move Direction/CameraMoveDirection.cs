using UnityEngine;

public class CameraMoveDirection : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector2 cameraInput;

    [Header("Elements")]
    [SerializeField] Camera activeCamera;

    private void Update()
    {
        GetCameraInput();
    }

    void GetCameraInput()
    {
        cameraInput.x = Input.GetAxis("Mouse X");
        cameraInput.y = Input.GetAxis("Mouse Y");
        cameraInput.Normalize();
    }
}