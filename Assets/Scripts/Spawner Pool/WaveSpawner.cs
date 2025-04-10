using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;

    public int amountToSpawn;

    public List<GameObject> activeEnemies = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void CreateEnemy()
    {
        GameObject newEnemy = Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], transform.position, transform.rotation, transform.parent);

        activeEnemies.Add(newEnemy);
    }
}
