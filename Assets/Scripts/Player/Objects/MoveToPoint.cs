using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    public GameObject objectToMove;

    public float moveSpeed;

    public float ObjectSpawnTimer;
    private float ObjectSpawnTimerCounter;

    public Transform[] startPoints;
    public Transform[] endPoints;

    public Transform selectedStartPoint;
    public Transform selectedEndPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObjectSpawnTimerCounter = ObjectSpawnTimer;

        SelectSpawnPoint();
        SelectEndPoint();
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectSpawnPoint()
    {
        selectedStartPoint = startPoints[Random.Range(0, startPoints.Length)];
    }

    void SelectEndPoint()
    {
        selectedEndPoint = endPoints[Random.Range(0, endPoints.Length)];
    }

    void SpawnObject()
    {
        Instantiate(objectToMove, selectedStartPoint.position, Quaternion.identity);
    }
}
