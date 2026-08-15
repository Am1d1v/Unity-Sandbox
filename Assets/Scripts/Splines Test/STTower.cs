using UnityEngine;
using UnityEngine.Splines;

public class STTower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform playerPosition;

    [Header("Elements")]
    [SerializeField] SplineContainer splineContainer;

    private void OnMouseDown()
    {
        Debug.Log("A");
    }
}
