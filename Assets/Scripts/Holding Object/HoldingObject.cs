using UnityEngine;

public class HoldingObject : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePosition;
    [SerializeField] Vector2 itemPoint;
    [SerializeField] LayerMask objectLayer;
    

    [Header("Object Settings")]
    [SerializeField] GameObject movingItem;
    [SerializeField] float moveSpeed;
    [SerializeField] float distanceToBreak;

    private void Update()
    {
        GetMousePosition();

        MoveItem();
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

    void MoveItem()
    {
        if (new Vector2(movingItem.transform.position.x, movingItem.transform.position.y) != itemPoint && InDistance() && movingItem != null)
        {
            movingItem.transform.position = Vector3.MoveTowards(movingItem.transform.position, new Vector2(itemPoint.x, itemPoint.y), moveSpeed * Time.deltaTime);
        }
    }

    bool InDistance()
    {
        if(Vector3.Distance(transform.position, movingItem.transform.position) <= distanceToBreak)
        {
            movingItem.GetComponent<Rigidbody>().useGravity = false;
            movingItem.GetComponent<Rigidbody>().isKinematic = true;

            return true;
        }
        else
        {
            movingItem.GetComponent<Rigidbody>().useGravity = true;
            movingItem.GetComponent<Rigidbody>().isKinematic = false;
            movingItem = null;
            return false;
        }
    }

}