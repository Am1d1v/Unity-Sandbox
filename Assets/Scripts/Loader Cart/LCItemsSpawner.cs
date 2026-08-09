using UnityEngine;

public class LCItemsSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] LCItem itemPrefab;
    [SerializeField] float minSpawnDelay;
    [SerializeField] float maxSpawnDelay;

    [Header("Elements")]
    [SerializeField] Collider boxCollider;

    private void Start()
    {
        SpawnItem();
    }

    void SpawnItem()
    {
        float selectedXPosition = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);

        Instantiate(itemPrefab, new Vector3(selectedXPosition, 0f, 0f) + transform.position, Quaternion.identity, transform);
    }
}