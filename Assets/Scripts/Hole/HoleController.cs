using UnityEngine;

public class HoleController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float moveSpeed;

    private void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");

        transform.position += new Vector3(moveDirection.x, 0f, moveDirection.y) * moveSpeed * Time.deltaTime; 
    }
}