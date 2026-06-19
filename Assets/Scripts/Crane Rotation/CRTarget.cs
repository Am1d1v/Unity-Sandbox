using System;
using UnityEngine;

public class CRTarget : MonoBehaviour
{
    public static event Action<Transform> onSelectRotationTarget;

    private void OnMouseDown()
    {
        SelectRotationTarget();
    }

    public void SelectRotationTarget()
    {
        onSelectRotationTarget?.Invoke(this.gameObject.transform);
    }
}