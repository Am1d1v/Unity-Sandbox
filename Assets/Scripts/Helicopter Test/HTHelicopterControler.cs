using UnityEngine;
using UnityEngine.InputSystem;

public class HTHelicopterControler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 yImpact;
    [SerializeField] Vector3 moveImpact;
    [SerializeField] Vector3 totalImpact;

    [Header("Elements")]
    [SerializeField] CharacterController characterController;

    [Header("Input Actions")]
    [SerializeField] InputActionReference MoveInput;

    private void Update()
    {
        GetMoveInput();

        CalculateYVelocity();

        Move();
    }

    void CalculateYVelocity()
    {
        if (characterController.isGrounded)
        {
            yImpact.y = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            yImpact.y += Physics.gravity.y * Time.deltaTime;
        }
    }

    void GetMoveInput()
    {
        moveImpact.x = MoveInput.action.ReadValue<Vector2>().x;
        moveImpact.z = MoveInput.action.ReadValue<Vector2>().y;

        moveImpact = new Vector3(moveImpact.x, 0f, moveImpact.z) * moveSpeed * Time.deltaTime;
    }

    void Move()
    {
        characterController.Move((moveImpact + yImpact) * Time.deltaTime);
    }
}