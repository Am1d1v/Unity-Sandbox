using System.Collections.Generic;
using UnityEngine;

public class CallToArms : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float callRange;
    [SerializeField] List<GameObject> calledUnits = new List<GameObject>();
    [SerializeField] CallToArmsEnemyType enemyType;
    public CallToArmsEnemyType EnemyType => enemyType;

    [ContextMenu("Call Units")]
    void CallUnits()
    {
        Collider[] effectedUnits = Physics.OverlapSphere(transform.position, callRange);

        foreach(Collider unit in effectedUnits)
        {
            if(unit.TryGetComponent<CallToArms>(out CallToArms enemy) && enemy.EnemyType == CallToArmsEnemyType.Warrior)
            {
                calledUnits.Add(unit.gameObject);
            }
        }
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