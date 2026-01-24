using UnityEngine;

public class AEPC : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] CharacterController characterController;
    [SerializeField] Animator animator;

    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] Transform moveDetectorPosition;

    private void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical");

        animator.SetFloat("movedirection", Input.GetAxisRaw("Vertical"));

        characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

        if(moveDirection.magnitude > 0f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void Rotate()
    {
        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawSphere(moveDetectorPosition.position, 0.45f);
    }
}