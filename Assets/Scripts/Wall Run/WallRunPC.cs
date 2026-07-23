using UnityEngine;
using UnityEngine.InputSystem;

public class WallRunPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpStrength;
    [SerializeField] float detectionRange;
    [SerializeField] float detectionRayLength;
    [SerializeField] bool isWallRun;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] Vector3 detectionPosition;
    [SerializeField] Vector3 normal;
    [SerializeField] Quaternion rotation;
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

        IsWallDetected();

        //SetModelVisualRotation();

        SetModelNormal();
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

    bool IsWallDetected()
    {
        isWallRun = Physics.CheckSphere(transform.position + detectionPosition, detectionRange, wallLayer);

        return isWallRun;
    }

    void SetModelVisualRotation()
    {
        if (isWallRun)
        {
            visualModel.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
        else
        {
            visualModel.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }

    void SetModelNormal()
    {
        Ray ray = new Ray(transform.position, visualModel.transform.up * -1.5f);

        RaycastHit hit;
          
        Debug.DrawRay(transform.position, visualModel.transform.up * -1.5f, Color.magenta);

        if(Physics.Raycast(ray, out hit, 1.5f, wallLayer))
        {
            Debug.Log(hit.collider.gameObject.name);

            normal = hit.normal;
        }

        visualModel.transform.rotation = Quaternion.FromToRotation(visualModel.transform.up, normal) * visualModel.transform.rotation;

        rotation = visualModel.transform.rotation;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position + detectionPosition, detectionRange);
    }
}