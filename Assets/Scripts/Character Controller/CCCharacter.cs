using UnityEngine;

public class CCCharacter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 totalMovement;

    [Header("Elements")]
    [SerializeField] CharacterController controller;

    private void Update()
    {
        CalculateYVelocity();

        Move();
    }

    void CalculateYVelocity()
    {
        Vector3 movement = new Vector3(0f, Physics.gravity.y * Time.deltaTime, 0f);

        if (controller.isGrounded)
        {
            totalMovement = movement;
        }
        else
        {
            totalMovement += movement;
        }
    }

    void Move()
    {
        controller.Move(totalMovement);
    }
}