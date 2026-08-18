using UnityEngine;

public class PSPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float detectionRange;
    [SerializeField] Vector3 detectionOffset;
    [SerializeField] GameObject platformPrefab;

    private void Start()
    {
        CreatePlatform();
    }

    void CreatePlatform()
    {
        Instantiate(platformPrefab, transform.position + detectionOffset, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireCube(transform.position + detectionOffset, Vector3.one * detectionRange);
    }
}