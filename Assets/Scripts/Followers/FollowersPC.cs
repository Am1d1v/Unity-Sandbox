using UnityEngine;
using UnityEngine.InputSystem;

public class FollowersPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector2 moveDirection;

    [Header("Elements")]
    [SerializeField] Rigidbody rb;

    [Header("Actions")]
    [SerializeField] InputActionReference moveAction;

    private void Update()
    {
        moveDirection = moveAction.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {      
        rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.y) * moveSpeed;
    }
}