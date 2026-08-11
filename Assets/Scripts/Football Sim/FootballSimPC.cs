using UnityEngine;
using UnityEngine.InputSystem;

public class FootballSimPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 yVelocity;

    [Header("Elements")]
    [SerializeField] CharacterController characterController;

    [Header("Input Actions")]
    [SerializeField] InputActionReference moveInput;

    private void Update()
    {
        CalculateYVelocity();

        Move();
    }

    void Move()
    {
        Vector3 forwardInput = transform.forward * moveInput.action.ReadValue<Vector2>().y * moveSpeed * Time.deltaTime;

        characterController.Move(forwardInput);
    }

    void CalculateYVelocity()
    {
        if (characterController.isGrounded)
        {
            yVelocity = Vector3.up * Physics.gravity.y * Time.deltaTime;

            return;
        }

        yVelocity += Vector3.up * Physics.gravity.y * Time.deltaTime;
    }
}