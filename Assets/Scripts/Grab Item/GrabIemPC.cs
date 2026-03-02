using UnityEngine;

public class GrabIemPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float grabDistance;   
    [SerializeField] float rayHeight;   
    [SerializeField] bool canMove;
    [SerializeField] bool canRotate;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject holdingObject;
    [SerializeField] LayerMask grabItemMask;

    private void Update()
    {
        Rotate();

        if(Input.GetMouseButtonDown(0) && holdingObject == null)
        {
            GrabItem();
        }
        else if(Input.GetMouseButtonDown(0) && holdingObject != null)
        {
            DropItem();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical");

        rb.linearVelocity = moveDirection * moveSpeed;
    }

    void Rotate()
    {
        if (canRotate == false) return;

        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0f);
    }

    void GrabItem()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, grabItemMask))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
    
    void DropItem()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y + rayHeight, transform.position.z), transform.forward * grabDistance);
    }
}
