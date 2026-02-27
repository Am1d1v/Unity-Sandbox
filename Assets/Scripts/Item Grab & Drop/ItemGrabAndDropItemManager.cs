using System;
using UnityEngine;

public class ItemGrabAndDropItemManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject currentItem;
    [SerializeField] Ray ray;
    [SerializeField] float rayLength;
    [SerializeField] LayerMask movebleItemMask;

    [Header("Actions")]
    public static Action onItemClicked;

    private void Update()
    {      
        if (Input.GetMouseButtonDown(0) && currentItem == null)
        {
            DetectItem();

            onItemClicked?.Invoke();
        }
    }

    void DetectItem()
    {
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Camera.main.transform.position, ray.direction, out hit, rayLength, movebleItemMask))
        {
            currentItem = hit.collider.gameObject;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Gizmos.DrawRay(Camera.main.transform.position, ray.direction * rayLength);
    }
}