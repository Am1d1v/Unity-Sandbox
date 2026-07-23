using UnityEngine;
using UnityEngine.InputSystem;

public class WallRunPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpStrength;
    [SerializeField] Vector3 moveDirection;

    [Header("Elements")]
    [SerializeField] Rigidbody rb;

    [Header("Input Actions")]
    [SerializeField] InputActionReference moveInputAction;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}