using UnityEngine;

public class AEPC : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] CharacterController characterController;

    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 moveDirection;

    private void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical");

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        characterController.transform.rotation = Quaternion.Euler(0f, characterController.transform.rotation.y + Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0f);
    }
}