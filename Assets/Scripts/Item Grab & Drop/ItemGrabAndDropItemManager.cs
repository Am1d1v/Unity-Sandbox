using UnityEngine;

public class ItemGrabAndDropItemManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject currentItem;
    [SerializeField] Ray ray;
    [SerializeField] float rayLength;

    private void Update()
    {
        DetectItem();
    }

    void DetectItem()
    {
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Camera.main.transform.position, ray.direction, out hit, rayLength))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);

            Debug.DrawRay(hit.normal, reflectDir * rayLength, Color.red, 3f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Gizmos.DrawRay(Camera.main.transform.position, ray.direction * rayLength);
    }
}