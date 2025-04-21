using UnityEngine;

public class SortedMovingObject : MonoBehaviour
{
    public string color;

    public float moveSpeed;

    public bool atTheMiddlePoint;

    public Transform pointToMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!atTheMiddlePoint)
        {
            MoveToTheMiddle();
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

    void MoveToTheSpicificPoint(string objectColor)
    {
        switch (objectColor)
        {
            case "Pink":

                    break;
            case "Black":

                break;
            case "Blue":

                break;
        }
    }
}
