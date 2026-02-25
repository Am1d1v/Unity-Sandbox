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
    }

    void Move()
    {
        moveInput = Input.GetAxisRaw("Vertical");

        float yAxis = rb.linearVelocity.y;

        rb.linearVelocity = transform.forward * moveInput * moveSpeed;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, yAxis, rb.linearVelocity.z);

    }
}