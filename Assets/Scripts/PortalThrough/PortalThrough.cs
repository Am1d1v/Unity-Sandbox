using UnityEngine;

public class PortalThrough : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float portalPointerMoveSpeed;
    [SerializeField] float detectionRadius;
    [SerializeField] bool collidedWithObstacle;
    [SerializeField] bool pointerCasted;
    [SerializeField] LayerMask obstacleMask;
    [SerializeField] GameObject portalPointer;

    private void Update()
    {      
        if (Input.GetMouseButtonDown(0))
        {
            pointerCasted = true;
        }
        else if (Input.GetMouseButtonDown(1) && pointerCasted)
        {
            ResetPortalPointer();
        }

        if (pointerCasted)
        {
            MovePortalPointer();
        }
    }

    void MovePortalPointer()
    {
        portalPointer.transform.position += transform.up * portalPointerMoveSpeed * Time.deltaTime;
    }

    void DetectObstacle()
    {
        Collider[] colliders = Physics.OverlapSphere(portalPointer.transform.position, detectionRadius, obstacleMask);

        if(colliders.Length > 0)
        {
            collidedWithObstacle = true;
        }
    }

    void ResetPortalPointer()
    {
        pointerCasted = false;

        portalPointer.transform.position = Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireSphere(portalPointer.transform.position, detectionRadius);
    }
}