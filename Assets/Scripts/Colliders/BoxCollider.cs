using UnityEngine;

public class BoxCollider : MonoBehaviour
{
    public Collider[] objectsInRange;

    public LayerMask objectToAdd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetObjects();
    }

    void GetObjects()
    {
        objectsInRange = Physics.OverlapBox(transform.position, transform.localPosition, Quaternion.identity, objectToAdd);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    }
}
