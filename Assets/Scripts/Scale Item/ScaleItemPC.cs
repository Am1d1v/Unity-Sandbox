using UnityEngine;

public class ScaleItemPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] CharacterController characterController;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Vertical");

        Vector3 move = Vector3.forward * moveInput * moveSpeed * Time.deltaTime;

        characterController.Move(move);
    }
}