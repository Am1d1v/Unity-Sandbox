using System.Collections.Generic;
using UnityEngine;

public class SpreadItemsBetween : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] List<GameObject> itemsToSpread = new List<GameObject>();
    [SerializeField] float moveSpeed;
    [SerializeField] Transform leftBorder;
    [SerializeField] Transform rightBorder;

    void SpreadItems()
    {

    }

}