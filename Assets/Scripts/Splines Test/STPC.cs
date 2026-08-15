using UnityEngine;
using UnityEngine.Splines;

public class STPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float splineMovementDuration;
    [SerializeField] float splineProgress;

    [Header("Elements")]
    [SerializeField] SplineContainer splineContainer;

    private void Awake()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    private void Update()
    {
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

    //public void SetSpline(Vector3 position, SplineContainer SC, float splineDuration)
    //{
    //    transform.position = position;

    //    splineMovementDuration = splineDuration;

    //    splineContainer = SC;
    //}

    void SetSplineTower()
    {

    }
}