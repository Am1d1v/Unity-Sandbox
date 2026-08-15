using UnityEngine;

public class CCCharacter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 totalMovement;
    [SerializeField] float gravityImpact;
    [SerializeField] float gravityGrounded = -1.5f;
    [SerializeField] float moveSpeed;

    [Header("Elements")]
    [SerializeField] CharacterController controller;

    private void Update()
    {
        CalculateYVelocity();

        Move();
    }

    void CalculateYVelocity()
    {
        gravityImpact = Physics.gravity.y;

        if (controller.isGrounded)
        {
            totalMovement.y = gravityGrounded;
        }
        else
        {
            totalMovement.y += gravityImpact * Time.deltaTime;
        }
    }

    void Move()
    {
        totalMovement.z = Input.GetAxisRaw("Vertical") * moveSpeed;

        controller.Move(totalMovement * Time.deltaTime);
    }
}