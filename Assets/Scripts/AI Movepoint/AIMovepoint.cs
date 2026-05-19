using UnityEngine;

public class AIMovepoint : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePos;
    [SerializeField] Vector3 movePoint;
    [SerializeField] Ray ray;
    [SerializeField] float rayLength;
    [SerializeField] LayerMask groundLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetMovePoint();
        }
    }

    void SetMovePoint()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayLength, groundLayer))
        {
            Debug.DrawRay(Camera.main.transform.position, ray.direction * rayLength);

            movePoint = new Vector3(hit.point.x, 0f, hit.point.z);
        }

        
    }
}