using UnityEngine;

public class OTObstacleAnimation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float cameraRotationTreshold;
    [SerializeField] float currentCameraRotationValue;
    [SerializeField] Animator animator;


    private void Update()
    {
        currentCameraRotationValue = Mathf.Abs(OTCameraController.instance.YRotationValue);

        if (currentCameraRotationValue >= cameraRotationTreshold)
        {
            animator.Play("UnderGround");
        }
        
    }
}