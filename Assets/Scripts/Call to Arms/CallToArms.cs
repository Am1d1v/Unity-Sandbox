using UnityEngine;

public class CallToArms : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float callRange;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.position, callRange);
    }
}