using System;
using UnityEngine;

public class ScaleItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 scaleEffect;

    [Header("Actions")]
    public static Action onPlayerCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            onPlayerCollision?.Invoke();
        }
    }
}