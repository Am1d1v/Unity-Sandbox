using UnityEngine;

public class PortalThrough : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float portalPointerMoveSpeed;
    [SerializeField] float detectionRadius;
    [SerializeField] bool isMoving;
    [SerializeField] GameObject portalPointer;

    private void Update()
    {
        MovePortalPointer();
    }

    void MovePortalPointer()
    {
        Collider[] colliders = Physics.OverlapSphere(portalPointer.transform.position, detectionRadius);

        Debug.Log(colliders.Length);
    }
}