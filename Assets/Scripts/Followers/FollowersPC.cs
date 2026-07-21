using UnityEngine;
using UnityEngine.InputSystem;

public class FollowersPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float followerOrderLength;
    [SerializeField] float followerOrderRadius;
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

    void CastOrder()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.position + transform.forward * followerOrderLength, followerOrderRadius);
    }
}