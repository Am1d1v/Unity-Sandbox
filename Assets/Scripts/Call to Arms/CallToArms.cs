using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CallToArms : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float callRange;
    [SerializeField] float moveSpeed;
    [SerializeField] List<CallToArms> calledUnits = new List<CallToArms>();
    [SerializeField] CallToArmsEnemyType enemyType;
    [SerializeField] Transform movePoint;
    public CallToArmsEnemyType EnemyType => enemyType;

    [Header("Elements")]
    [SerializeField] NavMeshAgent agent;

    private void Start()
    {
        agent.speed = moveSpeed;
    }

    private void Update()
    {
        Move();
    }

    [ContextMenu("Call Units")]
    void CallUnits()
    {
        Collider[] effectedUnits = Physics.OverlapSphere(transform.position, callRange);

        foreach(Collider unit in effectedUnits)
        {
            if(unit.TryGetComponent<CallToArms>(out CallToArms enemy) && enemy.EnemyType == CallToArmsEnemyType.Warrior)
            {
                calledUnits.Add(unit.GetComponent<CallToArms>());
            }
        }

        foreach(CallToArms unit in calledUnits)
        {
            unit.SetMovePoint(transform);
        }

    }

    public void SetMovePoint(Transform moveDirection)
    {
        if (enemyType == CallToArmsEnemyType.Caller) return;

        movePoint = moveDirection;
    }

    void Move()
    {
        if (movePoint == null) return;

        agent.SetDestination(movePoint.position);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.position, callRange);
    }
}

public enum CallToArmsEnemyType
{
    Caller,
    Warrior
}