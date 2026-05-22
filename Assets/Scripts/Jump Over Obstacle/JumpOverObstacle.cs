using UnityEngine;

public class JumpOverObstacle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpStrength;
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
        //MoveForward();
    }

    bool isObstacleDetected()
    {
        if (Physics.OverlapSphere(transform.position + datectionZone, detectionRadius, obstacleLayer).Length > 0)
        {
            Jump();

            return true;
        }

        return false;
    }

    void MoveForward()
    {
        rb.linearVelocity = transform.forward * moveSpeed;
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(0f, jumpStrength, rb.linearVelocity.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + datectionZone, detectionRadius);
    }
}