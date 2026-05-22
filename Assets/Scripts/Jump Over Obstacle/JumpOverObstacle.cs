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

    private void Update()
    {
        isObstacleDetected();
    }

    private void FixedUpdate()
    {
        
    }

    bool isObstacleDetected()
    {
        if (Physics.OverlapSphere(transform.position + datectionZone, detectionRadius, obstacleLayer).Length > 0)
        {
            Debug.Log("T");

            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + datectionZone, detectionRadius);
    }
}