using System.Collections.Generic;
using UnityEngine;

public class ClampSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;

    public GameObject objectToChase;

    public Transform minSpawnPoint, maxSpawnPoint;

    public List<Vector3> spawnPoints = new List<Vector3>();

    public List<GameObject> spawnedObjects = new List<GameObject>();

    public float moveSpeed, rangeToChase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        RangeCheck(objectToChase.transform.position);

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

    void ChasePlayer(Vector3 objectToChase)
    {
        foreach (GameObject obj in spawnedObjects)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, objectToChase, moveSpeed * Time.deltaTime);
        }

        
    }

    void RangeCheck(Vector3 objectToChase)
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if(Vector3.Distance(obj.transform.position, objectToChase) <= rangeToChase)
            {
                ChasePlayer(objectToChase);
            }
        }

        Debug.Log(objectToChase);
    }
}
