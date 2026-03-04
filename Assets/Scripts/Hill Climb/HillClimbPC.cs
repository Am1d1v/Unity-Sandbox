using System;
using UnityEngine;

public class HillClimbPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 rockOffset;
    [SerializeField] HillClimb selectedRock;
    [SerializeField] Rigidbody rb;

    [Header("Actions")]
    public static HillClimbPC instance;

    private void Awake()
    {
        instance = this; 
    }

    private void Update()
    {
        if (selectedRock)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            selectedRock = null;

            rb.isKinematic = false;
        }
    }

    public void SelectRock(HillClimb rock)
    {
        selectedRock = rock;
    }

    void Move()
    {
        if(Vector3.Distance(transform.position, selectedRock.transform.position) >= 0.1f)
        {
            rb.isKinematic = true;

            transform.position = Vector3.Slerp(transform.position, selectedRock.transform.position + rockOffset, moveSpeed * Time.deltaTime);
        }
        
        if(Vector3.Distance(transform.position, selectedRock.transform.position + rockOffset) < 0.1f)
        {
            selectedRock = null;
        }
    }
}