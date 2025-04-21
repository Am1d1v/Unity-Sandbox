using System.Collections.Generic;
using UnityEngine;

public class SortingPath : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    public List<GameObject> activeObjects = new List<GameObject>();

    public Transform objectHolder;

    public Transform middlePoint;

    public Transform[] sortingPoints;

    public static SortingPath instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpawnNewObject();
    }

    private void Update()
    {
        if(activeObjects.Count == 0)
        {
            SpawnNewObject();
        }
    }
    public void SpawnNewObject()
    {
        int objectIndex = Random.Range(0, objectsToSpawn.Length);

        GameObject spawnedObject = Instantiate(objectsToSpawn[objectIndex], transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation, objectHolder);

        activeObjects.Add(spawnedObject);

    }

}
