using UnityEngine;

public class GrabIemPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float grabDistance;   
    [SerializeField] float rayHeight;   
    [SerializeField] float moveTrashlod;   
    [SerializeField] bool canMove;
    [SerializeField] bool canRotate;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] Rigidbody rb;
    [SerializeField] GrabItem holdingObject;
    [SerializeField] LayerMask grabItemMask;

    private void Update()
    {
        //Rotate();

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

        Rotate();
    }

    void Move()
    {
        if (canMove == false) return;

        moveDirection = transform.forward * Input.GetAxisRaw("Vertical");

        rb.linearVelocity = moveDirection * moveSpeed;
    }

    void Rotate()
    {
        if (canRotate == false) return;

        //transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0f);

        float rotationInput = Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;

        Vector3 rotation = transform.eulerAngles;

        rb.MoveRotation(Quaternion.Euler(rotation + new Vector3(0f, rotationInput, 0f)));
    }

    void GrabItem()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, grabItemMask))
        {
            GrabItem item = hit.collider.gameObject.GetComponent<GrabItem>();

            item.Grab(transform);

            holdingObject = item;           

            if(holdingObject.GetMass() > moveTrashlod)
            {
                canMove = false;

                canRotate = false;
            }
        }
    }
    
    void DropItem()
    {
        holdingObject.Release();

        canMove = true;

        canRotate = true;

        holdingObject = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y + rayHeight, transform.position.z), transform.forward * grabDistance);
    }
}
