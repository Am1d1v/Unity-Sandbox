using UnityEngine;

public class CraneRotation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform rotationTarget;

    private void OnEnable()
    {
        CRTarget.onSelectRotationTarget += SelectRotationTarget;
    }

    private void OnDisable()
    {
        CRTarget.onSelectRotationTarget -= SelectRotationTarget;
    }

    private void Update()
    {
        LookAtTarget();
    }

    void LookAtTarget()
    {
        if (rotationTarget == null) return;

        Quaternion lookDirection = Quaternion.LookRotation(rotationTarget.position);

        if(transform.rotation != lookDirection)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, Time.deltaTime);
        }
    }

    void SelectRotationTarget(Transform target)
    {
        rotationTarget = target;
    }
}