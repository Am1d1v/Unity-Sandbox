using System;
using UnityEngine;

public class CRTarget : MonoBehaviour
{
    public static event Action<GameObject> onSelectRotationTarget;

    private void OnMouseDown()
    {
        Debug.Log("A");
    }
}