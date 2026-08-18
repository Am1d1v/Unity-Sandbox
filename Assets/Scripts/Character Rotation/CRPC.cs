using UnityEngine;
using UnityEngine.InputSystem;

public class CRPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector2 rotationInput;

    [Header("Input Actions")]
    [SerializeField] InputActionReference RotationInputAction;

    private void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        rotationInput.x = RotationInputAction.action.ReadValue<Vector2>().x;


    }
}