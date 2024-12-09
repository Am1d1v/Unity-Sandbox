using Unity.VisualScripting;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Following();
    }

    void Following()
    {
        if(Vector3.Distance(objectToFollow.position, transform.position) > 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, 0.1f);
        }
        
    }
}
