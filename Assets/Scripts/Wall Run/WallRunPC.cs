using UnityEngine;
using UnityEngine.InputSystem;

public class WallRunPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpStrength;
    [SerializeField] bool isWallRun;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] LayerMask wallLayer;

    [Header("Elements")]
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject visualModel;

    [Header("Input Actions")]
    [SerializeField] InputActionReference moveInputAction;
    [SerializeField] InputActionReference jumpInputAction;

    private void Update()
    {
        moveDirection = moveInputAction.action.ReadValue<Vector2>();       
    }

    private void FixedUpdate()
    {
        Move();

        Jump();       
    }

    void Move()
    {
        if (moveDirection.magnitude == 0) return;

        if (isWallRun)
        {
            rb.linearVelocity = transform.up * moveSpeed * moveDirection.y;           
        }
        else
        {
            rb.linearVelocity = transform.forward * moveSpeed * moveDirection.y;           
        }       
    }

    void Jump()
    {       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpStrength, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            isWallRun = true;

            visualModel.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            isWallRun = false;

            visualModel.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}