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
    [SerializeField] List<Followers> followers = new List<Followers>();

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
        Collider[] orderPointColliders = Physics.OverlapSphere(transform.position + transform.forward * followerOrderLength, followerOrderRadius);

        if(orderPointColliders.Length > 0)
        {
            foreach(Collider collider in orderPointColliders)
            {
                Debug.Log(collider.gameObject.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.position + transform.forward * followerOrderLength, followerOrderRadius);
    }
}