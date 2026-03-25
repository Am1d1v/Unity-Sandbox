using UnityEngine;

public class PortalThrough : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float portalPointerMoveSpeed;
    [SerializeField] float detectionRadius;
    [SerializeField] float portalPointerLifetime;
    [SerializeField] float portalPointerLifetimeCounter;
    [SerializeField] bool collidedWithObstacle;
    [SerializeField] bool pointerCasted;
    [SerializeField] LayerMask obstacleMask;
    [SerializeField] GameObject portalPointer;
    [SerializeField] Vector3 teleportationPoint;

    private void Update()
    {      
        if (Input.GetMouseButtonDown(0))
        {
            pointerCasted = true;

            portalPointerLifetimeCounter = portalPointerLifetime;
        }
        else if (Input.GetMouseButtonDown(1) && pointerCasted)
        {
            ResetPortalPointer();
        }

        if (pointerCasted)
        {
            MovePortalPointer();

            portalPointerLifetimeCounter -= Time.deltaTime;
           
            collidedWithObstacle = DetectObstacle();
        } 
        
        if (pointerCasted && collidedWithObstacle == false)
        {
            teleportationPoint = portalPointer.transform.position;

            TeleportPlayer();

            ResetPortalPointer();
        }
    }

    void MovePortalPointer()
    {
        portalPointer.transform.position += transform.up * portalPointerMoveSpeed * Time.deltaTime;
    }

    bool DetectObstacle()
    {
        Collider[] colliders = Physics.OverlapSphere(portalPointer.transform.position, detectionRadius, obstacleMask);

        if(colliders.Length > 0)
        {           
            return true;
        }
     
        return false;
    }

    void ResetPortalPointer()
    {
        pointerCasted = false;

        portalPointer.transform.position = transform.position;

        ResetPortalPointerTimer();
    }
    
    void ResetPortalPointerTimer()
    {
        portalPointerLifetimeCounter = portalPointerLifetime;
    }

    void TeleportPlayer()
    {
        transform.position = portalPointer.transform.position;

        ResetPortalPointer();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireSphere(portalPointer.transform.position, detectionRadius);
    }
}