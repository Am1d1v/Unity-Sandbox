using UnityEngine;

public class PSPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float detectionRange;
    [SerializeField] int selectedPlatformSpawnPosition;
    [SerializeField] Vector3 detectionOffset;
    [SerializeField] Vector3[] platformPositions;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] LayerMask platformLayer;

    private void Start()
    {
        CreatePlatform();

        DetectPlatform();
    }

    void CreatePlatform()
    {
        selectedPlatformSpawnPosition = Random.Range(0, platformPositions.Length);

        Instantiate(platformPrefab, transform.position + platformPositions[selectedPlatformSpawnPosition], Quaternion.identity);
    }

    void DetectPlatform()
    {
        if(Physics.CheckBox(transform.position + platformPositions[selectedPlatformSpawnPosition], Vector3.one * detectionRange, Quaternion.identity, platformLayer))
        {
            Debug.Log("Platform");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireCube(transform.position + detectionOffset, Vector3.one * detectionRange);
    }
}