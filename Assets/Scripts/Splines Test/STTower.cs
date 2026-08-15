using UnityEngine;
using UnityEngine.Splines;

public class STTower : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] SplineContainer splineContainer;

    private void OnMouseDown()
    {
        Debug.Log("A");
    }
}
