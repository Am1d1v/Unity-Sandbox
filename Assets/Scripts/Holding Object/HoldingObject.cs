using UnityEngine;

public class HoldingObject : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePosition;
    [SerializeField] Vector2 itemPoint;
    [SerializeField] LayerMask objectLayer;
    [SerializeField] GameObject movingItem;
    private void Update()
    {
        GetMousePosition();
    }

    void GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePosition = mousePos;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, objectLayer))
        {
            Debug.DrawLine(ray.origin, hit.point);

            itemPoint = new Vector2(hit.point.x, hit.point.y);
        }        
    }



}