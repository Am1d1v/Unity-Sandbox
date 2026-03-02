using UnityEngine;

public class GrabIemPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] Rigidbody rb;
    [SerializeField] bool canMove;

    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical");

        rb.linearVelocity = moveDirection * moveSpeed;
    }

    void Rotate()
    {
        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0f);
    }
}
