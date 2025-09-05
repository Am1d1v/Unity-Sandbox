using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    [SerializeField] List<GameObject> apples = new List<GameObject>();

    [SerializeField] Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        int randomAppleIndex = Random.Range(0, apples.Count);

        GameObject selectedApple = apples[randomAppleIndex];
        selectedApple.GetComponent<SphereCollider>().enabled = true;
        selectedApple.GetComponent<Rigidbody>().useGravity = true;

        animator.SetTrigger("treeShake");

        apples.Remove(apples[randomAppleIndex]);
    }
}
