using UnityEngine;

public class LiftPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float moveInput;
    [SerializeField] float rotationInput;
    [SerializeField] Rigidbody rb;

    private void FixedUpdate()
    {
        Move();

        Rotate();
    }

    void Move()
    {
        moveInput = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = transform.forward * moveInput * moveSpeed;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, -6f, rb.linearVelocity.z);
    }

    void Rotate()
    {
        rotationInput = Input.GetAxisRaw("Horizontal");

        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + (rotationInput * rotationSpeed),0f);
    }
}