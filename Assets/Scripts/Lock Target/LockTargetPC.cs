using UnityEngine;

public class LockTargetPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform target;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Vector3 moveInput;

    private void Update()
    {
        LookAtTheTarget();
    }

    void LookAtTheTarget()
    {
        if (target == null) return;

        targetPosition = target.position - transform.position;
        targetPosition.y = 0f;

        transform.rotation = Quaternion.LookRotation(targetPosition, transform.up);
    }
}