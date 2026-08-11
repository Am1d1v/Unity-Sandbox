using UnityEngine;
using UnityEngine.InputSystem;

public class FootballSimPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;

    [Header("Elements")]
    [SerializeField] CharacterController characterController;

    [Header("Input Actions")]
    [SerializeField] InputActionReference moveInput;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        characterController.Move(transform.forward * moveInput.action.ReadValue<Vector2>().y * moveSpeed * Time.deltaTime);
    }
}