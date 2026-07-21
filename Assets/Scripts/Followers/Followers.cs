using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Followers : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float stoppingDistance;
    [SerializeField] Vector3 orderDestination;

    [Header("Elements")]
    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent.speed = moveSpeed;

        navMeshAgent.stoppingDistance = stoppingDistance;
    }

    private void Update()
    {
        navMeshAgent.SetDestination(orderDestination);
    }

    public void SetOrderPosition(Vector3 orderPosition)
    {
        orderDestination = orderPosition;
    }
}