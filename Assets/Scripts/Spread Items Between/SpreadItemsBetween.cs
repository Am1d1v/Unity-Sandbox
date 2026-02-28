using System.Collections.Generic;
using UnityEngine;

public class SpreadItemsBetween : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] List<GameObject> itemsToSpread = new List<GameObject>();
    [SerializeField] float moveSpeed;
    [SerializeField] Transform leftBorder;
    [SerializeField] Transform rightBorder;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpreadItems();
        }
    }

    void SpreadItems()
    {
        if(itemsToSpread.Count == 1)
        {
            itemsToSpread[0].transform.position = rightBorder.position + leftBorder.position;
        }
    }

}