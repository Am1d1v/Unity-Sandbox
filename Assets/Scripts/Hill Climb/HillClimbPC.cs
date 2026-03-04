using System;
using UnityEngine;

public class HillClimbPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] HillClimb selectedRock;

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
    }

    public void SelectRock(HillClimb rock)
    {
        selectedRock = rock;
    }

    void Move()
    {
        if(Vector3.Distance(transform.position, selectedRock.transform.position) >= 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, selectedRock.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}