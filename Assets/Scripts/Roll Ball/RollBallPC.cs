using UnityEngine;

public class RollBallPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotatiobSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 moveInput;

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {

    }

    void Rotate()
    {

    }
}