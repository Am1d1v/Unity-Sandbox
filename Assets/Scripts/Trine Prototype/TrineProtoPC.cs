using UnityEngine;

public class TrineProtoPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePos;
    [SerializeField] Vector3 raycastHit;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float rayLength;


    private void Update()
    {
        GetMousePos();

        GetRaycast();
    }

    void GetMousePos()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;

        mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void GetRaycast()
    {
        RaycastHit hit;
      
        if(Physics.Raycast(transform.position, mousePos, out hit, rayLength, groundLayer))
        {
            raycastHit = hit.point;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(Camera.main.transform.position, new Vector3(mousePos.x, mousePos.y, rayLength));
    }
}