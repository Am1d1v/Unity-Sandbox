using UnityEngine;

public class OTCameraController : MonoBehaviour
{
    public static OTCameraController instance;

    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float yRotationValue;
    public float YRotationValue => yRotationValue;

    [Header("Elements")]
    [SerializeField] Camera mainCamera;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        float rotationInput = Input.GetAxisRaw("Horizontal");

        transform.Rotate(new Vector3(0f, rotationInput * moveSpeed, 0f) * Time.deltaTime);

        yRotationValue = transform.rotation.eulerAngles.y;

        if (transform.rotation.eulerAngles.y > 180f)
        {
            yRotationValue -= 360f;
        }

    }
}