using UnityEngine;
using UnityEngine.Splines;

public class STPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float splineMovementDuration;
    [SerializeField] float splineProgress;

    [Header("Elements")]
    [SerializeField] SplineContainer splineContainer;

    private void Update()
    {
        SplineMove();
    }

    void SplineMove()
    {
        splineProgress += Time.deltaTime * moveSpeed / splineMovementDuration;

        transform.position = splineContainer.EvaluatePosition(splineProgress);

        if(splineProgress >= 1f)
        {
            Debug.Log("Exit spline movement state");
        }
    }
}