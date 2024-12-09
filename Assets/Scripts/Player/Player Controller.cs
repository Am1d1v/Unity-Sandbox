using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;

    private PlayerControls playerControls;

    private Vector3 movement;

    private Rigidbody rb;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector3>();
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
}
