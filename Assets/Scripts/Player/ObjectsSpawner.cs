using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    public Transform spawnPoint;

    public Transform obstaclesContainer;

    public int x, y;

    public int amountOfObstacles;

    public float obstaclesMovespeed;

    public List<GameObject> spawnedObstacles = new List<GameObject>();

    private void Start()
    {
        //Spawn();
        GenerateObstacles();
    }

    private void Update()
    {
        MoveObstacles();
    }

    //private void Spawn()
    //{
    //    for (int i = 1; i <= x; i++)
    //    {
    //        for (int j = 0; j < y; j++)
    //        {
    //            if(Random.value > 0.7)
    //            {
    //                Instantiate(objectToSpawn, transform.position += new Vector3(0f, 0f, 1.5f), Quaternion.identity);


    //            }
    //            else
    //            {
    //                spawnPoint.position += new Vector3(0f, 0f, 1.5f);
    //                j++;
    //            }



    //        }

    //        spawnPoint.position = new Vector3(i * 1.5f, 0f, 0f);
    //    }

    //}

    private void GenerateObstacles()
    {
        for (int i = 0; i < amountOfObstacles; i++)
        {
            GameObject newObstacles;

            if (i == 0)
            {
                newObstacles = Instantiate(objectToSpawn, transform.position += Vector3.zero, Quaternion.identity);
            }
            else
            {
                newObstacles = Instantiate(objectToSpawn, transform.position += new Vector3(0f, 0f, 6f), Quaternion.identity);
            }
            
            spawnedObstacles.Add(newObstacles);
        }
    }
    private void MoveObstacles()
    {
        foreach(GameObject obstacle in spawnedObstacles)
        {
            obstacle.transform.position -= new Vector3(0f, 0f, obstaclesMovespeed * Time.deltaTime);
        }
    }

}
