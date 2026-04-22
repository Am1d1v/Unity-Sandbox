using UnityEngine;

public class OTCameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;

    [Header("Elements")]
    [SerializeField] Camera mainCamera;

    private void Update()
    {
        float rotationInput = Input.GetAxisRaw("Horizontal");

        transform.Rotate(new Vector3(0f, rotationInput * moveSpeed, 0f) * Time.deltaTime);
    }
}