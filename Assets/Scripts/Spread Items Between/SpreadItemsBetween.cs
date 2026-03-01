using System.Collections.Generic;
using UnityEngine;

public class SpreadItemsBetween : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] List<GameObject> itemsToSpread = new List<GameObject>();   
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
        if (itemsToSpread.Count == 0) return;

        if(itemsToSpread.Count == 1)
        {
            itemsToSpread[0].transform.position = rightBorder.position + leftBorder.position;
        }
        else
        {
            float startPosition = (rightBorder.position.x + Mathf.Abs(leftBorder.position.x)) / itemsToSpread.Count;
            float offsetBetweenItems = startPosition / 2;

            for (int i = 0; i < itemsToSpread.Count; i++)
            {
                itemsToSpread[i].transform.position = new Vector3(startPosition, itemsToSpread[i].transform.position.y, itemsToSpread[i].transform.position.z);

                startPosition += offsetBetweenItems;
            }
        }
    }

}