using UnityEngine;
using UnityEngine.AI;

public class Followers : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;

    [Header("Elements")]
    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent.speed = moveSpeed;
    }

    private void Update()
    {
        navMeshAgent.SetDestination(player.position);
    }
}