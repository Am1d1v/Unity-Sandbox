using UnityEngine;

public class LiftPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float moveInput;
    [SerializeField] Vector2 rotationInput;
    [SerializeField] Rigidbody rb;
    [SerializeField] Camera camera;

    private void FixedUpdate()
    {
        Move();

        Rotate();

        CastRay();
    }

    void Move()
    {
        moveInput = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = transform.forward * moveInput * moveSpeed;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, -6f, rb.linearVelocity.z);
    }

    void Rotate()
    {
        rotationInput.x = Input.GetAxisRaw("Mouse X");
        rotationInput.y = Input.GetAxisRaw("Mouse Y");

        // Horizontal
        if(rotationInput.x != 0f)
        {
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + (rotationInput.x * rotationSpeed), 0f);
        }
    }

    void CastRay()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, transform.forward, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawRay(Camera.main.transform.position, transform.forward);
    }
}