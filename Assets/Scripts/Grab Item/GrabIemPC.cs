using UnityEngine;

public class GrabIemPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float grabDistance;   
    [SerializeField] bool canMove;
    [SerializeField] bool canRotate;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject holdingObject;
    [SerializeField] LayerMask grabItemMask;

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
        if (canRotate == false) return;

        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0f);
    }

    void GrabItem()
    {
        Physics.Raycast(transform.position, transform.forward, grabDistance, grabItemMask);
    }
}
