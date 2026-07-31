using UnityEngine;

public class CameraMoveDirection : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector2 cameraInput;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float moveSpeed;

    [Header("Elements")]
    [SerializeField] Camera activeCamera;

    private void Update()
    {
        //GetCameraInput();

        Move();
    }

    Vector3 GetCameraInput()
    {
        cameraInput.x = Input.GetAxis("Mouse X");
        cameraInput.y = Input.GetAxis("Mouse Y");
        cameraInput.Normalize();

        return activeCamera.transform.forward * cameraInput;
    }

    void Move()
    {
        transform.position += GetCameraInput() * moveSpeed;
    }
}