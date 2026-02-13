using UnityEngine;

public class ISPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] int currentSelectedSpawnerIndex;
    [SerializeField] CharacterController characterController;
    [SerializeField] Collider detectionCollider;

    private void Update()
    {
        Move();

        Rotate();

        SpawnersCheck();
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

    void SpawnersCheck()
    {

    }
}