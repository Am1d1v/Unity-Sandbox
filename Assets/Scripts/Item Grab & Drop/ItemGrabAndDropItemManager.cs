using UnityEngine;

public class ItemGrabAndDropItemManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject currentItem;
    [SerializeField] GameObject indicator;
    [SerializeField] Vector3 mousePos;
    [SerializeField] float rayLength;

    private void Update()
    {
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Gizmos.DrawRay(Camera.main.transform.position, ray.direction * rayLength);
    }
}