using UnityEngine;

public class JumpOverObstacle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float detectionRadius;
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] Vector3 datectionZone;

    [Header("Elements")]
    [SerializeField] Rigidbody rb;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + datectionZone, detectionRadius);
    }
}