using UnityEngine;

public class PSPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float detectionRange;
    [SerializeField] Vector3 detectionOffset;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireCube(transform.position + detectionOffset, Vector3.one * detectionRange);
    }
}