using UnityEngine;

public class ParkourPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float checkRadius;
    [SerializeField] float hangLenght;
    [SerializeField] Vector3 checkPoint;
    [SerializeField] LayerMask hangLayer;


    private void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere((transform.position + checkPoint) * hangLenght, checkRadius);
    }
}