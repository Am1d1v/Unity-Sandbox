using UnityEngine;

public class SortedMovingObject : MonoBehaviour
{
    public string color;

    public float moveSpeed;

    public bool atTheMiddlePoint, atTheEndPoint;

    public Transform pointToMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectMovePoint(color);
    }

    // Update is called once per frame
    void Update()
    {
        if (!atTheMiddlePoint)
        {
            MoveToTheMiddle();
        }
        else
        {
            MoveToTheSpicificPoint();
        }
    }

    void MoveToTheMiddle()
    {
        transform.position = Vector3.MoveTowards(transform.position, SortingPath.instance.middlePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, SortingPath.instance.middlePoint.position) < 0.1f)
        {
            atTheMiddlePoint = true;
        }
    }

    void MoveToTheSpicificPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointToMove.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, pointToMove.position) < 0.1f)
        {
            Destroy(gameObject);

            SortingPath.instance.activeObjects.Remove(gameObject);
        }
    }

    void SelectMovePoint(string objectColor)
    {
        switch (objectColor)
        {
            case "Pink":
                pointToMove = SortingPath.instance.sortingPoints[0];
                break;
            case "Blue":
                pointToMove = SortingPath.instance.sortingPoints[1];
                break;
            case "Black":
                pointToMove = SortingPath.instance.sortingPoints[2];
                break;
        }
    }
}
