using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Followers : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float stoppingDistance;
    [SerializeField] Transform orderDestination;

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
        if(orderDestination != null && Vector3.Distance(transform.position, orderDestination.position) >= stoppingDistance)
        {
            navMeshAgent.SetDestination(orderDestination.position);
        }
        else
        {
            orderDestination = null;

            navMeshAgent.SetDestination(player.position);
        }
    }

    public void SetOrderPosition(Transform orderPosition)
    {
        orderDestination = orderPosition;
    }
}