using UnityEngine;
using UnityEngine.InputSystem;

public class CMDCinemacihinePC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 mouseInput;

    [Header("Elements")]
    [SerializeField] Camera mainCamera;
    [SerializeField] CharacterController characterController;

    [Header("Input Actions")]
    [SerializeField] InputActionReference mouseDeltaAction;

    private void Start()
    {
        
    }

    private void Update()
    {
        GetMouseInputDelta();

        Move();

        FaceMovementDirection();
    }

    void GetMouseInputDelta()
    {
        mouseInput = mouseDeltaAction.action.ReadValue<Vector2>().normalized;
    }

    void Move()
    {
        characterController.Move(mainCamera.transform.forward * moveSpeed * Time.deltaTime);
    }

    void FaceMovementDirection()
    {
        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0f;

        transform.rotation = Quaternion.LookRotation(forward);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0f;

        Gizmos.DrawWireSphere(forward, 1f);
    }
}