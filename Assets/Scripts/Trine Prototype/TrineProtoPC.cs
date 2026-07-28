using UnityEngine;

public class TrineProtoPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePos;
    [SerializeField] Vector3 raycastHit;
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] float rayLength;

    [Header("Elements")]
    [SerializeField] GameObject holdingObject;


    private void Update()
    {
        GetMousePos();

        if (Input.GetMouseButtonDown(0))
        {
            GetRaycast();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DropObject();
        }

        if(holdingObject != null)
        {
            MoveHoldingObject();
        }
    }

    void GetMousePos()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = rayLength;

        mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void DropObject()
    {
        holdingObject = null;
    }

    void MoveHoldingObject()
    {
        holdingObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
    }

    void GetRaycast()
    {
        RaycastHit hit;
      
        if(Physics.Raycast(Camera.main.transform.position, new Vector3(mousePos.x, mousePos.y, rayLength), out hit, rayLength, obstacleLayer))
        {
            holdingObject = hit.collider.gameObject;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(Camera.main.transform.position, new Vector3(mousePos.x, mousePos.y, rayLength));
    }
}