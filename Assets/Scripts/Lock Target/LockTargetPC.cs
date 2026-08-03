using UnityEngine;

public class LockTargetPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform target;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Vector3 moveInput;
    [SerializeField] float moveSpeed;

    private void Update()
    {
        LookAtTheTarget();

        Move();
    }

    void LookAtTheTarget()
    {
        if (target == null) return;

        targetPosition = target.position - transform.position;
        targetPosition.y = 0f;

        transform.rotation = Quaternion.LookRotation(targetPosition, transform.up);
    }

    void Move()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        transform.position += (moveInput * moveSpeed + targetPosition.normalized) * Time.deltaTime;
    }
}