using UnityEngine;

public class OTObstacle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float cameraRotationTreshold;
    [SerializeField] float currentCameraRotationValue;
    [SerializeField] ObstacleState obstacleState;

    private void Start()
    {
        obstacleState = ObstacleState.OnGround;
    }

    private void Update()
    {
        currentCameraRotationValue = Mathf.Abs(OTCameraController.instance.YRotationValue);
    }
}

public enum ObstacleState
{
    OnGround,
    UnderGround
}