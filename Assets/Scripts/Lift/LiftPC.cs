using UnityEngine;

public class LiftPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float moveInput;
    [SerializeField] Vector2 rotationInput;
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
        rotationInput.x = Input.GetAxisRaw("Mouse X");

        // Horizontal
        if(rotationInput.x != 0f)
        {
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + (rotationInput.x * rotationSpeed), 0f);
        }       
    }
}