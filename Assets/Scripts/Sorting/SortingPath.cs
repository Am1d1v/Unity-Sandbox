using UnityEngine;

public class SortingPath : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    public Transform objectHolder;

    public Transform middlePoint;

    public Transform[] sortingPoints;

    private void Start()
    {
        SpawnNewObject();
    }
    public void SpawnNewObject()
    {
        int objectIndex = Random.Range(0, objectsToSpawn.Length);

        Instantiate(objectsToSpawn[objectIndex], transform.position, transform.rotation, objectHolder);
    } 

}
