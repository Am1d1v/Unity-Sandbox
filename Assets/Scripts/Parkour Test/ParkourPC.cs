using UnityEngine;
using UnityEngine.UIElements;

public class ParkourPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float checkRadius;
    [SerializeField] float hangLenght;
    [SerializeField] float hangSpeed;
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

        if(Physics.Raycast(transform.position, checkPoint * hangLenght, out hit, hangLenght, hangLayer) && Input.GetKeyDown(KeyCode.Space))
        {
            hangObject = hit.collider.gameObject.transform;
        }
    }

    void Hang()
    {
        if (hangObject == null) return;

        if (transform.position != hangObject.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, hangObject.position, hangSpeed * Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        //Gizmos.DrawWireSphere(transform.position + checkPoint * hangLenght, checkRadius);
    }
}