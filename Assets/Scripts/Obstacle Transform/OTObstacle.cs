using UnityEngine;

public class OTObstacle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float cameraRotationTreshold;
    [SerializeField] float currentCameraRotationValue;
    [SerializeField] float onGroundYValue;
    [SerializeField] float underGroundYValue;
    [SerializeField] ObstacleState obstacleState;

    private void Start()
    {
        obstacleState = ObstacleState.OnGround;

        onGroundYValue = transform.position.y;
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
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, onGroundYValue, transform.position.z), moveSpeed * Time.deltaTime);
                break;
            case ObstacleState.UnderGround:
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, underGroundYValue, transform.position.z), moveSpeed * Time.deltaTime);
                break;
        }
    }
}

public enum ObstacleState
{
    OnGround,
    UnderGround
}