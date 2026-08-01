using UnityEngine;
using UnityEngine.UIElements;

public class ParkourPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float checkRadius;
    [SerializeField] float hangLenght;
    [SerializeField] float hangSpeed;
    [SerializeField] float accelarateSpeed;
    [SerializeField] Vector3 checkPoint;
    [SerializeField] Vector3 targetPoint;
    [SerializeField] Vector3 checkOffset;
    [SerializeField] Vector3 hangOffset;
    [SerializeField] LayerMask hangLayer;
    [SerializeField] Transform hangObject;


    private void Update()
    {
        //CheckToHang();

        Hang();

        SetCheckSphere();

        CheckHangSphere();
    }

    void CheckToHang()
    {
        checkPoint = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * hangLenght;

        RaycastHit hit;

        if(Physics.Raycast(transform.position + checkOffset, checkPoint * hangLenght, out hit, hangLenght, hangLayer) && Input.GetKeyDown(KeyCode.Space))
        {
            if (hangObject == null)
            {
                hangObject = hit.collider.gameObject.transform;
            }
            else if(hangObject != hit.collider.gameObject)
            {
                hangObject = hit.collider.gameObject.transform;
            }
        }
    }

    void CheckHangSphere()
    {
        Collider[] hangObjects = Physics.OverlapSphere(transform.position + targetPoint + checkOffset, checkRadius, hangLayer);

        if (hangObjects.Length > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            hangObject = hangObjects[0].transform;
        }
    }


    void SetCheckSphere()
    {
        targetPoint.x += Input.GetAxisRaw("Horizontal") * accelarateSpeed * Time.deltaTime;
        targetPoint.y += Input.GetAxisRaw("Vertical") * accelarateSpeed * Time.deltaTime;
    }

    void Hang()
    {
        if (hangObject == null) return;

        if (transform.position != hangObject.position + hangOffset)
        {
            transform.position = Vector3.MoveTowards(transform.position, hangObject.position + hangOffset, hangSpeed * Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawSphere(transform.position + targetPoint + checkOffset, checkRadius);

        //Gizmos.DrawRay(transform.position + checkOffset, checkPoint);
    }
}