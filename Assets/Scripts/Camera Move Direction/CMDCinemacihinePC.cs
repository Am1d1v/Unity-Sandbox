using UnityEngine;
using UnityEngine.InputSystem;

public class CMDCinemacihinePC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 mouseInput;

    [Header("Elements")]
    [SerializeField] Camera mainCamera;

    [Header("Input Actions")]
    [SerializeField] InputActionReference mouseDeltaAction;

    private void Start()
    {
        
    }

    private void Update()
    {
        GetMouseInputDelta();
    }

    void GetMouseInputDelta()
    {
        mouseInput = mouseDeltaAction.action.ReadValue<Vector2>();
    }
}