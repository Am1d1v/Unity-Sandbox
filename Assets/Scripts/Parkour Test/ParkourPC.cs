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
        CheckToHang();
    }

    void CheckToHang()
    {
        checkPoint = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * hangLenght;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position + checkPoint * hangLenght, checkRadius);
    }
}