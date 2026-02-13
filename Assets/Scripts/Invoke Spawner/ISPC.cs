using UnityEngine;

public class ISPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 moveInput;
    [SerializeField] CharacterController characterController;

    private void Update()
    {
        moveInput = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));

        characterController.Move(moveInput * moveSpeed * Time.deltaTime);
    }
}