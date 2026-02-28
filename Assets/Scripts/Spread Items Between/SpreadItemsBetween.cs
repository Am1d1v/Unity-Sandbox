using System.Collections.Generic;
using UnityEngine;

public class SpreadItemsBetween : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] List<GameObject> itemsToSpread = new List<GameObject>();
    [SerializeField] float moveSpeed;
    [SerializeField] float leftBorder;
    [SerializeField] float rightBorder;

    void SpreadItems()
    {

    }

}