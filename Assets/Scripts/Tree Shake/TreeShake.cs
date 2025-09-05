using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    [SerializeField] List<GameObject> apples = new List<GameObject>();

    private void OnMouseDown()
    {
        int randomAppleIndex = Random.Range(0, apples.Count);

        GameObject selectedApple = apples[randomAppleIndex];
        selectedApple.GetComponent<SphereCollider>().enabled = true;
        selectedApple.GetComponent<Rigidbody>().useGravity = true;

        apples.Remove(apples[randomAppleIndex]);
    }
}
