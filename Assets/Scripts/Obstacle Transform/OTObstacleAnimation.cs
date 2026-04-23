using UnityEngine;

public class OTObstacleAnimation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float cameraRotationTreshold;
    [SerializeField] float currentCameraRotationValue;
    [SerializeField] Animator animator;
    [SerializeField] ObstacleType obstacleType;


    private void Update()
    {
        currentCameraRotationValue = Mathf.Abs(OTCameraController.instance.YRotationValue);

        switch (obstacleType)
        {
            case ObstacleType.GroundMove:
                GroundMove();
                break;
        }
    }
    void GroundMove()
    {
        if (currentCameraRotationValue >= cameraRotationTreshold)
        {
            animator.Play("UnderGround");
        }
        else
        {
            animator.Play("OnGround");
        }
    }
}

public enum ObstacleType
{
    GroundMove,
    AirMove
}