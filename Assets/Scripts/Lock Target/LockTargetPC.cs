using UnityEngine;

public class LockTargetPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform target;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Vector3 moveInput;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float moveSpeed;

    private void Update()
    {
        LookAtTheTarget();

        //GetMoveInput();

        MoveAround();
    }

    void LookAtTheTarget()
    {
        if (target == null) return;

        targetPosition = target.position - transform.position;
        targetPosition.y = 0f;

        transform.rotation = Quaternion.LookRotation(targetPosition, transform.up);
    }

    void GetMoveInput()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveDirection = (transform.forward * moveInput.z + transform.right * moveInput.x) * Time.deltaTime;

        transform.position += moveDirection * moveSpeed;
    }

    void MoveAround()
    {
        moveDirection = transform.right * Time.deltaTime;

        transform.position += moveDirection * moveSpeed;
    }
}