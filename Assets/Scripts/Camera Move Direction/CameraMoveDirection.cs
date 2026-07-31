using UnityEngine;

public class CameraMoveDirection : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 cameraInput;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float moveSpeed;

    [Header("Elements")]
    [SerializeField] Camera activeCamera;

    private void Update()
    {
        GetCameraInput();

        Rotate();

        Move();
    }

    void GetCameraInput()
    {
        cameraInput.x = Input.GetAxis("Mouse X");
        //cameraInput.y = Input.GetAxis("Mouse Y");
        cameraInput.Normalize();

        moveDirection = activeCamera.transform.forward + cameraInput;

        moveDirection.y = 0f;
    }

    void Rotate()
    {
        Vector3 currentEulerRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Euler(currentEulerRotation + new Vector3(0f, cameraInput.x, 0f) * Time.deltaTime);
    }

    void Move()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}