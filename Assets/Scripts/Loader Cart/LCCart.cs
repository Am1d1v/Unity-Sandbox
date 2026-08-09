using UnityEngine;
using UnityEngine.InputSystem;

public class LCCart : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 moveDirection;

    [Header("Elements")]
    [SerializeField] Rigidbody rb;

    [Header("Input Actions")]
    [SerializeField] InputActionReference MoveInput;

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void GetInput()
    {
        moveDirection.x = MoveInput.action.ReadValue<Vector2>().x;
    }

    void Move()
    {
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, 0f);
    }
}