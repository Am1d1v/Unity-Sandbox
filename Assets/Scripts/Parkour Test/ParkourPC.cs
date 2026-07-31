using UnityEngine;
using UnityEngine.UIElements;

public class ParkourPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float checkRadius;
    [SerializeField] float hangLenght;
    [SerializeField] float hangSpeed;
    [SerializeField] bool canHang;
    [SerializeField] bool isHanged;
    [SerializeField] Vector3 checkPoint;
    [SerializeField] LayerMask hangLayer;
    [SerializeField] Transform hangObject;


    private void Update()
    {
        CheckToHang();

        Hang();
    }

    void CheckToHang()
    {
        checkPoint = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * hangLenght;

        RaycastHit hit;

        //canHang = Physics.CheckSphere(transform.position + checkPoint * hangLenght, checkRadius, hangLayer);

        if(Physics.Raycast(transform.position, checkPoint * hangLenght, out hit, hangLayer))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }

    void Hang()
    {
        if (canHang)
        {
            //transform.SetParent(hangObject);

            if(transform.position != hangObject.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, hangObject.position, hangSpeed * Time.deltaTime);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        //Gizmos.DrawWireSphere(transform.position + checkPoint * hangLenght, checkRadius);
    }
}