using UnityEngine;

public class PlayerCapsuleController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] Vector3 moveInput;

    RaycastHit hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(moveInput.x, 0f, moveInput.y) * moveSpeed * Time.deltaTime;

        
        // Align with surface
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            transform.rotation = Quaternion.LookRotation(hit.transform.forward, hit.normal);
        }

        
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log(mousePos);

        if (Vector3.Distance(transform.position, mousePos) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
           
        }

        
    }

}
