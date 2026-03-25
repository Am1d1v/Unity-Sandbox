using UnityEngine;

public class PortalThrough : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float portalPointerMoveSpeed;
    [SerializeField] float detectionRadius;
    [SerializeField] bool isMoving;
    [SerializeField] LayerMask obstacleMask;
    [SerializeField] GameObject portalPointer;

    private void Update()
    {
        MovePortalPointer();
    }

    void MovePortalPointer()
    {
        Collider[] colliders = Physics.OverlapSphere(portalPointer.transform.position, detectionRadius, obstacleMask);

        Debug.Log(colliders.Length);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireSphere(portalPointer.transform.position, detectionRadius);
    }
}