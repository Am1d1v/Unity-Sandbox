using UnityEngine;

public class ItemGrabAndDropItemManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject currentItem;
    [SerializeField] Vector3 mousePos;
    [SerializeField] float rayLength;

    private void Update()
    {
        GetMousePos();

        MousePos();
    }

    void MousePos()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, mousePos, out hit, rayLength))
        {
            Debug.Log(hit.collider.gameObject);
        }
    }

    void GetMousePos()
    {
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawRay(Camera.main.transform.position, mousePos);
    }
}