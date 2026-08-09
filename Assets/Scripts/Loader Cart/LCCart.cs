using UnityEngine;
using UnityEngine.InputSystem;

public class LCCart : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 moveDirection;

    [Header("Input Actions")]
    [SerializeField] InputActionReference MoveInput;

    private void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        moveDirection.x = MoveInput.action.ReadValue<Vector2>().x;
    }
}