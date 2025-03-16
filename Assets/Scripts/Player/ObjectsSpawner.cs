using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    public int x, y;

    public GameObject objectToSpawn;

    public Transform spawnPoint;


    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 1; i <= x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if(Random.value > 0.5)
                {
                    Instantiate(objectToSpawn, transform.position += new Vector3(0f, 0f, 1.5f), Quaternion.identity);
                }
                else
                {
                    transform.position += new Vector3(0f, 0f, 1.5f);
                    j++;
                }
                
            }

            spawnPoint.position = new Vector3(i * 1.5f, 0f, 0f);
        }

    }
}
