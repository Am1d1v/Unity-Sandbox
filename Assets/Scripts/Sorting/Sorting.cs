using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    public GameObject objectToSpawn;

    public List<GameObject> handledObjects = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        GameObject newObj = Instantiate(objectToSpawn);

        handledObjects.Add(newObj);
    }
}
