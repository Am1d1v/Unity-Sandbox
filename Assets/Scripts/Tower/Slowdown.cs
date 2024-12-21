using UnityEngine;

public class Slowdown : MonoBehaviour
{
    public float range = 300f;

    public float slowdown = 0.5f;

    public Collider[] collidersInRange;

    public LayerMask whatToSlow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collidersInRange = Physics.OverlapSphere(transform.position, range, whatToSlow);
        
        Debug.Log(collidersInRange.Length);
    }
}
