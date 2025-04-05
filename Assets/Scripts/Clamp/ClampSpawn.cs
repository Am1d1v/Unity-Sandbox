using System.Collections.Generic;
using UnityEngine;

public class ClampSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;

    public GameObject objectToChase;

    public Transform minSpawnPoint, maxSpawnPoint;

    public List<Vector3> spawnPoints = new List<Vector3>();

    public List<GameObject> spawnedObjects = new List<GameObject>();

    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        objectToSpawn.transform.position += Vector3.MoveTowards(objectToSpawn.transform.position, objectToChase.transform.position, moveSpeed * Time.deltaTime);
    }

    Vector3 SelectSpawnPoint()
    {
        float xPos = Random.Range(minSpawnPoint.position.x, maxSpawnPoint.position.x);
        float yPos = Random.Range(minSpawnPoint.position.z, maxSpawnPoint.position.z);

        return new Vector3(xPos, 0.6f, yPos);
    }

    void SpawnObject()
    {
        Vector3 spawnPoint = SelectSpawnPoint();
        spawnPoints.Add(spawnPoint);

        GameObject newObject = Instantiate(objectToSpawn, spawnPoint, Quaternion.identity);
        spawnedObjects.Add(newObject);
    }
}
