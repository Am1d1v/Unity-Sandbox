using System;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemGrabAndDropItemManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject currentItem;
    [SerializeField] Ray ray;
    [SerializeField] float rayLength;
    [SerializeField] LayerMask movebleItemMask;
    [SerializeField] Vector3 currentItemOffset;

    private void Update()
    {      
        if (Input.GetMouseButtonDown(0) && currentItem == null)
        {
            DetectItem();
        }
        else if(Input.GetMouseButtonDown(0) && currentItem != null)
        {
            DropItem();
        }

        if(currentItem != null)
        {
            UpdateCurrentItemPosition();
        }
    }

    void DetectItem()
    {
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Camera.main.transform.position, ray.direction, out hit, rayLength, movebleItemMask))
        {
            GameObject item = hit.collider.gameObject;

            GrabItem(item);

            item.GetComponent<ItemGrabAndDropItem>().SetDefaultRotationCO();
        }
    }

    void GrabItem(GameObject item)
    {
        currentItem = item;

        currentItem.GetComponent<Rigidbody>().useGravity = false;
    }

    void DropItem()
    {
        currentItem.GetComponent<Rigidbody>().useGravity = true;

        currentItem = null;       
    }

    void UpdateCurrentItemPosition()
    {
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Camera.main.transform.position, ray.direction, out hit))
        {
            currentItem.transform.position = hit.point + currentItemOffset;
        }
    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Gizmos.DrawRay(Camera.main.transform.position, ray.direction * rayLength);
    }
}