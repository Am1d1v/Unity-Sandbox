using UnityEngine;
using UnityEngine.InputSystem;

public class FootballSimPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 yVelocity;
    [SerializeField] Vector3 totalMotion;

    [Header("Elements")]
    [SerializeField] CharacterController characterController;

    [Header("Input Actions")]
    [SerializeField] InputActionReference moveInput;

    private void Update()
    {
        Move();

        Rotate();
    }

    void Move()
    {
        Vector3 forwardInput = transform.forward * moveInput.action.ReadValue<Vector2>().y * moveSpeed * Time.deltaTime;
        Vector3 gravityInput = CalculateYVelocity();

        totalMotion = forwardInput + gravityInput;

        characterController.Move(forwardInput + gravityInput);
    }

    Vector3 CalculateYVelocity()
    {
        yVelocity = Vector3.up * Physics.gravity.y * Time.deltaTime;

        return yVelocity;
    }

    void Rotate()
    {
        Vector3 lookInput = transform.position + transform.right * moveInput.action.ReadValue<Vector2>().x;

        transform.LookAt(lookInput);
    }
}