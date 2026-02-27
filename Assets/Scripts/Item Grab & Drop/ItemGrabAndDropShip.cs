using UnityEngine;

public class ItemGrabAndDropShip : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int cargoAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ItemGrabAndDropItem>(out ItemGrabAndDropItem item))
        {
            cargoAmount++;
        }
    }
}