using UnityEngine;

public class GrabIemPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] bool canMove;

    private void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical");
    }


    void Rotate()
    {
        transform.Rotate(0f, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0f);
    }
}
