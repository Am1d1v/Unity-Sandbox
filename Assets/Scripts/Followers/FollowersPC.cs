using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowersPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float followerOrderLength;
    [SerializeField] float followerOrderRadius;
    [SerializeField] Vector2 moveDirection;
    [SerializeField] Vector3 playerPosition;
    [SerializeField] List<Followers> followers = new List<Followers>();
    [SerializeField] Transform orderPoint;

    [Header("Elements")]
    [SerializeField] Rigidbody rb;

    [Header("Actions")]
    [SerializeField] InputActionReference moveAction;

    private void Update()
    {
        moveDirection = moveAction.action.ReadValue<Vector2>();

        if (Input.GetMouseButtonDown(0))
        {
            CastOrder();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {      
        rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.y) * moveSpeed;
    }

    void CastOrder()
    {
        Ray orderRay = new Ray(transform.position + playerPosition, transform.forward * followerOrderLength);

        RaycastHit hit;

        if (Physics.Raycast(orderRay, out hit))
        {
            followers[0].SetOrderPosition(hit.transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawRay(transform.position + playerPosition, transform.forward * followerOrderLength);
    }
}