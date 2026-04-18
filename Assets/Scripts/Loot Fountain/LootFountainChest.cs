using System.Collections.Generic;
using UnityEngine;

public class LootFountainChest : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] bool isOpened;
    [SerializeField] Transform lootSpawnPoint;
    [SerializeField] int lootAmount;
    [SerializeField] LFLoot lootPrefab;

    void OpenChest()
    {
        SetLoot();

        Debug.Log("Open");

        isOpened = true;
    }

    void SetLoot()
    {
        for(int i = 0; i < lootAmount; i++)
        {
            Instantiate(lootPrefab, lootSpawnPoint.position, Quaternion.identity);
        }
    }

    private void OnMouseDown()
    {
        if(isOpened == false)
        {
            OpenChest();
        }
    }
}