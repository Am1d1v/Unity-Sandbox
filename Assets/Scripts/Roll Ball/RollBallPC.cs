using UnityEngine;

public class RollBallPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 moveInput;

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        moveInput.z = Input.GetAxisRaw("Vertical") * moveSpeed;

        rb.linearVelocity = transform.forward * moveInput.z + new Vector3(0f, rb.linearVelocity.y, 0f);
    }

    void Rotate()
    {
        moveInput.y = Input.GetAxisRaw("Horizontal") * moveSpeed;

        rb.angularVelocity = new Vector3(0f, moveInput.y * rotationSpeed, 0f);
    }
}