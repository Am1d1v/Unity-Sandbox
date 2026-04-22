using UnityEngine;

public class OTObstacle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float cameraRotationTreshold;
    [SerializeField] float currentCameraRotationValue;
    [SerializeField] Vector3 onGroundPosition;
    [SerializeField] Vector3 underGroundPosition;
    [SerializeField] ObstacleState obstacleState;

    private void Start()
    {
        obstacleState = ObstacleState.OnGround;

        onGroundPosition = transform.position;
    }

    private void Update()
    {
        currentCameraRotationValue = Mathf.Abs(OTCameraController.instance.YRotationValue);

        if(currentCameraRotationValue >= cameraRotationTreshold)
        {
            obstacleState = ObstacleState.UnderGround;
        }
        else
        {
            obstacleState = ObstacleState.OnGround;
        }

        Move();
    }

    void Move()
    {
        switch (obstacleState)
        {
            case ObstacleState.OnGround:
                transform.position = Vector3.MoveTowards(transform.position, onGroundPosition, moveSpeed * Time.deltaTime);
                break;
            case ObstacleState.UnderGround:
                transform.position = Vector3.MoveTowards(transform.position, underGroundPosition, moveSpeed * Time.deltaTime);
                break;
        }
    }
}

public enum ObstacleState
{
    OnGround,
    UnderGround
}