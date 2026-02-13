using UnityEngine;

public class ISPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] CharacterController characterController;

    private void Update()
    {
        Move();

        Rotate();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        characterController.Move(transform.forward * moveInput);
    }
    void Rotate()
    {
        float rotationInput = Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Rotate(new Vector3(0f, rotationInput, 0f));

    }
}