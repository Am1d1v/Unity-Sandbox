using UnityEngine;

public class CraneRotation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject rotationTarget;

    private void Update()
    {
        LookAtTarget();
    }

    void LookAtTarget()
    {
        transform.rotation = Quaternion.LookRotation(rotationTarget.transform.position);
    }
}