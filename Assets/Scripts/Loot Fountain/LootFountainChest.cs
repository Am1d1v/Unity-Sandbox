using UnityEngine;

public class LootFountainChest : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] bool isOpened;
    [SerializeField] Transform lootSpawnPoint;

    void OpenChest()
    {
        Debug.Log("Open");

        isOpened = true;
    }

    private void OnMouseDown()
    {
        if(isOpened == false)
        {
            OpenChest();
        }
    }
}