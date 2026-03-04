using UnityEngine;

public class RollBallPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float speedMagnitudeToRotateTrashold;
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

        rb.AddForce(transform.forward * moveInput.z + new Vector3(0f, rb.linearVelocity.y, 0f), ForceMode.Force);

        Debug.Log(rb.linearVelocity.magnitude);
    }

    void Rotate()
    {
        if (rb.linearVelocity.magnitude < speedMagnitudeToRotateTrashold) return;

        moveInput.y = Input.GetAxisRaw("Horizontal") * moveSpeed;

        rb.angularVelocity = new Vector3(0f, moveInput.y * rotationSpeed, 0f);
    }
}