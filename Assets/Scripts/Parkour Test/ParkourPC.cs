using UnityEngine;

public class ParkourPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float checkRadius;
    [SerializeField] float hangLenght;
    [SerializeField] bool canHang;
    [SerializeField] Vector3 checkPoint;
    [SerializeField] LayerMask hangLayer;
    [SerializeField] Transform hangObject;


    private void Update()
    {
        CheckToHang();
    }

    void CheckToHang()
    {
        checkPoint = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * hangLenght;

        canHang = Physics.CheckSphere(transform.position + checkPoint * hangLenght, checkRadius, hangLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position + checkPoint * hangLenght, checkRadius);
    }
}