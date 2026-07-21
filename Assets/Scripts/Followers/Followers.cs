using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Followers : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float stoppingDistance;   

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
        navMeshAgent.SetDestination(player.position);
    }
}