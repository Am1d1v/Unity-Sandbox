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
    }

    void GetMouseInputDelta()
    {
        mouseInput = mouseDeltaAction.action.ReadValue<Vector2>().normalized;
    }

    void Move()
    {
        characterController.Move(mainCamera.transform.forward * moveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position + mainCamera.transform.forward, 1f);
    }
}