using UnityEngine;

public class CameraMoveDirection : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 cameraInput;
    [SerializeField] Vector3 moveInput;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    [Header("Elements")]
    [SerializeField] Camera activeCamera;

    private void Update()
    {
        GetMoveInput();

        SetRotation();
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

    void GetMoveInput()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void SetRotation()
    {
        if (moveInput.magnitude == 0f) return;

        Vector3 lookDirection = transform.forward + new Vector3(moveInput.x, 0f, moveInput.z) * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}