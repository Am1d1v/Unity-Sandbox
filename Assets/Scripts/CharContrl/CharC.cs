using UnityEngine;

public class CharC : MonoBehaviour
{
    [SerializeField] float moveSpeed, jumpForce, rotationSpeed;

    [SerializeField] Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float rotationInput = Input.GetAxisRaw("Horizontal");        
        transform.Rotate(0f, rotationInput * rotationSpeed * Time.deltaTime, 0f);

        Debug.Log(transform.forward);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");

        float jumpStrength = 0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpStrength += jumpForce;
        }

        rb.linearVelocity = transform.forward * moveSpeed * forwardInput + new Vector3(0f, jumpStrength, 0f);
    }
}
