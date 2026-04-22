using UnityEngine;

public class OTObstacle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float cameraRotationTreshold;
    [SerializeField] float currentCameraRotationValue;

    private void Update()
    {
        currentCameraRotationValue = Mathf.Abs(OTCameraController.instance.YRotationValue);
    }
}