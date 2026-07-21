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
        if(orderDestination == null)
        {
            navMeshAgent.SetDestination(orderDestination.position);
        }
        else
        {
            navMeshAgent.SetDestination(player.position);
        }

        if(transform.position == orderDestination.position)
        {
            orderDestination = null;
        }
    }

    public void SetOrderPosition(Transform orderPosition)
    {
        orderDestination = orderPosition;
    }
}