using UnityEngine;

public class ClampSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;

    public Transform minSpawnPoint, maxSpawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 SelectSpawnPoint()
    {
        float xPos = Random.Range(minSpawnPoint.position.x, maxSpawnPoint.position.x);
        float yPos = Random.Range(minSpawnPoint.position.z, maxSpawnPoint.position.z);

        return new Vector3(xPos, 0.6f, yPos);
    }
}
