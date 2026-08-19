using UnityEngine;
using UnityEngine.InputSystem;

public class HTHelicopterControler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 yImpact;
    [SerializeField] Vector3 totalImpact;

    [Header("Elements")]
    [SerializeField] CharacterController characterController;

    [Header("Input Actions")]
    [SerializeField] InputActionReference MoveInput;

    private void Update()
    {
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

    void Move()
    {
        characterController.Move((totalImpact + yImpact) * Time.deltaTime);
    }
}