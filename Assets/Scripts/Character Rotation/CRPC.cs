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
        //RotateMethod();
        RotateMouse();
    }

    void RotateMethod()
    {
        rotationInput.x = RotationInputAction.action.ReadValue<Vector2>().x;

        transform.Rotate(new Vector2(0f, rotationInput.x) * rotationSpeed * Time.deltaTime);
    }
    
    void RotateMouse()
    {
        rotationInput.x = Input.GetAxisRaw("Mouse X");

        transform.Rotate(new Vector2(0f, rotationInput.x) * rotationSpeed * Time.deltaTime);
    }
}