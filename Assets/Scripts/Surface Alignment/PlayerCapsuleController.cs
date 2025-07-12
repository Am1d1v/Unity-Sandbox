using UnityEngine;

public class PlayerCapsuleController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] Vector3 moveInput;

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
    }
}
