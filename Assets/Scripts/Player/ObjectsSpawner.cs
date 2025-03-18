using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    public int x, y;

    public GameObject objectToSpawn;

    public Transform spawnPoint;

    public int amountOfObstacles;

    private void Start()
    {
        //Spawn();
        GenerateObstacles();
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
            if (i == 0)
            {
                Instantiate(objectToSpawn, transform.position += Vector3.zero, Quaternion.identity);
            }
            Instantiate(objectToSpawn, transform.position += new Vector3(0f, 0f, 6f), Quaternion.identity);
        }
    }
}
