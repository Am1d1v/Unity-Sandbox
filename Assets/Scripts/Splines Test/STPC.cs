using UnityEngine;
using UnityEngine.Splines;

public class STPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float splineMovementDuration;
    [SerializeField] float splineProgress;
    [SerializeField] float splineTimer;

    [Header("Elements")]
    [SerializeField] SplineContainer splineContainer;

    private void Update()
    {
        splineTimer += Time.deltaTime;

        SplineMove();
    }

    void SplineMove()
    {
        if (splineContainer == null) return;

        splineProgress += Time.deltaTime / splineMovementDuration;

        transform.position = splineContainer.EvaluatePosition(splineProgress);

        if(splineProgress >= 1f)
        {
            Debug.Log("Exit spline movement state");

            splineContainer = null;

            splineProgress = 0f;
        }
    }
}