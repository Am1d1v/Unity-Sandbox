using UnityEngine;
using UnityEngine.InputSystem;

public class FollowersPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector2 moveDirection;

    [Header("Actions")]
    [SerializeField] InputActionReference moveAction;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        moveDirection = moveAction.action.ReadValue<Vector2>();
    }
}