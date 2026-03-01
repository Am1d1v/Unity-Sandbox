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
            float startPosition = (rightBorder.position.x + Mathf.Abs(leftBorder.position.x)) / itemsToSpread.Count; // 0.6

            float bordersOffset = startPosition * 2; // 1.2

            float itemsRange = (rightBorder.position.x + Mathf.Abs(leftBorder.position.x)) - bordersOffset; // 4.8

            float offsetBetweenItems = itemsRange / itemsToSpread.Count; // 0.48

            for (int i = 0; i < itemsToSpread.Count; i++)
            {
                Vector3 newPos = new Vector3(leftBorder.transform.position.x + startPosition, itemsToSpread[i].transform.position.y, itemsToSpread[i].transform.position.z);

                itemsToSpread[i].GetComponent<SpreadItemsBetweenIC>().SetPosition(newPos);

                startPosition += offsetBetweenItems;
            }
        }
    }

}