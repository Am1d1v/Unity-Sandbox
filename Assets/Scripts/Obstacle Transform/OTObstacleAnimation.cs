using UnityEngine;

public class OTObstacleAnimation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float cameraRotationTreshold;
    [SerializeField] float currentCameraRotationValue;
    [SerializeField] ObstacleState obstacleState;

    private void Update()
    {
        currentCameraRotationValue = Mathf.Abs(OTCameraController.instance.YRotationValue);

        if (currentCameraRotationValue >= cameraRotationTreshold)
        {
            obstacleState = ObstacleState.UnderGround;
        }
        else
        {
            obstacleState = ObstacleState.OnGround;
        }        
    }
}