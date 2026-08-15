using UnityEngine;
using UnityEngine.Splines;

public class STTower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform playerPosition;
    [SerializeField] float splineDuration;

    [Header("Elements")]
    [SerializeField] SplineContainer splineContainer;

    private void OnMouseDown()
    {
        STPC.instance.SetSpline(playerPosition.position, splineContainer, splineDuration);
    }
}
