using UnityEngine;

public class PSPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float detectionRange;
    [SerializeField] Vector3 detectionOffset;
    [SerializeField] Vector3[] platformPositions;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] LayerMask platformLayer;

    private void Start()
    {
        CreatePlatform();
    }

    void CreatePlatform()
    {
        int selectedPlatformSpawnPosition = Random.Range(0, platformPositions.Length);

        Instantiate(platformPrefab, transform.position + platformPositions[selectedPlatformSpawnPosition], Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireCube(transform.position + detectionOffset, Vector3.one * detectionRange);
    }
}