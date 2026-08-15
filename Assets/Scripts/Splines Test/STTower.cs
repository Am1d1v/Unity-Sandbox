using System;
using UnityEngine;
using UnityEngine.Splines;

public class STTower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform playerPosition;
    [SerializeField] float splineDuration;

    [Header("Elements")]
    [SerializeField] SplineContainer splineContainer;

    [Header("Events")]
    public event Action<Vector3, SplineContainer, float> onSetTower;

    private void OnMouseDown()
    {
        //STPC.instance.SetSpline(playerPosition.position, splineContainer, splineDuration);
        onSetTower?.Invoke(playerPosition.position, splineContainer, splineDuration);
    }
}
