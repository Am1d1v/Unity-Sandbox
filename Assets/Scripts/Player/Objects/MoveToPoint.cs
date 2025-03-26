using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject ship;

    public float moveSpeed;

    public bool isCreated;

    public Transform[] startPoints;
    public Transform[] endPoints;

    public Transform selectedStartPoint;
    public Transform selectedEndPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectSpawnPoint();
        SelectEndPoint();
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        ShipMove();

        DistanceCheck();
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
        GameObject newShip = Instantiate(objectToMove, selectedStartPoint.position, Quaternion.identity);

        ship = newShip;

        isCreated = true;
    }

    void ShipMove()
    {
        //ship.transform.position += new Vector3(0f, 0f, moveSpeed * Time.deltaTime);

        //ship.transform.position = Vector3.MoveTowards(selectedStartPoint.position, selectedEndPoint.position, moveSpeed * Time.deltaTime);

        ship.transform.position = Vector3.MoveTowards(ship.transform.position, selectedEndPoint.position, moveSpeed * Time.deltaTime);
    }

    void DistanceCheck()
    {
        if (Vector3.Distance(ship.transform.position, selectedEndPoint.position) < 0.1f)
        {
            Destroy(ship);
        }
    }
}
