using UnityEngine;
using UnityEngine.InputSystem;

public class WallRunPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpStrength;
    [SerializeField] Vector3 moveDirection;

    [Header("Elements")]
    [SerializeField] Rigidbody rb;

    [Header("Input Actions")]
    [SerializeField] InputActionReference moveInputAction;
    [SerializeField] InputActionReference jumpInputAction;

    private void Update()
    {
        moveDirection = moveInputAction.action.ReadValue<Vector2>();       
    }

    private void FixedUpdate()
    {
        Move();

        Jump();

        
    }

    void Move()
    {
        if (moveDirection.magnitude == 0) return;

        rb.linearVelocity = transform.forward * moveSpeed * moveDirection.y;
    }

    void Jump()
    {       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpStrength, ForceMode.Impulse);
        }
    }
}