using System.Collections.Generic;
using UnityEngine;

public class HoldingObject : MonoBehaviour
{
    public static HoldingObject instance;

    [Header("Settings")]
    [SerializeField] Vector3 mousePosition;
    [SerializeField] Vector2 itemPoint;
    [SerializeField] LayerMask objectLayer;
    
    [Header("Object Settings")]
    [SerializeField] GameObject movingItem;
    [SerializeField] float moveSpeed;
    [SerializeField] float distanceToBreak;
    [SerializeField] int objectToCreateIndex;
    [SerializeField] int currentObjectsAmount;
    [SerializeField] int maxItemAmount;
    [SerializeField] List<HOObject> objectsToCreate = new List<HOObject>();

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {       
        GetMousePosition();

        if (Input.GetMouseButtonDown(1))
        {
            UnsetItem();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateItem();
        }
        
        if (Input.GetKeyDown(KeyCode.N) && objectToCreateIndex < objectsToCreate.Count - 1)
        {
            objectToCreateIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.P) && objectToCreateIndex > 0)
        {
            objectToCreateIndex--;
        }

        MoveItem();
    }

    void GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePosition = mousePos;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, objectLayer))
        {
            Debug.DrawLine(ray.origin, hit.point);

            itemPoint = new Vector2(hit.point.x, hit.point.y);
        }        
    }

    void MoveItem()
    {
        if (movingItem == null) return;

        if (new Vector2(movingItem.transform.position.x, movingItem.transform.position.y) != itemPoint && InDistance())
        {
            movingItem.transform.position = Vector3.MoveTowards(movingItem.transform.position, new Vector2(itemPoint.x, itemPoint.y), moveSpeed * Time.deltaTime);
        }
    }

    public void SetItem(GameObject item)
    {
        movingItem = item;
    }

    void UnsetItem()
    {
        if(movingItem != null)
        {
            movingItem.GetComponent<Rigidbody>().useGravity = true;

            movingItem = null;
        }
    }

    void CreateItem()
    {
        if (currentObjectsAmount >= maxItemAmount && InDistance() == false) return;

        Instantiate(objectsToCreate[objectToCreateIndex], new Vector2(itemPoint.x, itemPoint.y), Quaternion.identity);

        currentObjectsAmount++;
    }

    bool InDistance()
    {
        if (Vector3.Distance(transform.position, movingItem.transform.position) <= distanceToBreak)
        {
            movingItem.GetComponent<Rigidbody>().useGravity = false;

            return true;
        }
        else
        {
            movingItem.GetComponent<Rigidbody>().useGravity = true;
            movingItem = null;

            return false;
        }
    }

}