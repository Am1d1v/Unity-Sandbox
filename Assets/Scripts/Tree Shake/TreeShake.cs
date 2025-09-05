using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    [SerializeField] List<GameObject> apples = new List<GameObject>();

    private void OnMouseDown()
    {
        int randomAppleIndex = Random.Range(0, apples.Count);

        Debug.Log(apples[randomAppleIndex]);
    }
}
