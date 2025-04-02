using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;

    public float speedMod = 1f;

    public float checkRadius;

    public Material color;

    private PlayerControls playerControls;

    private Vector3 movement;

    private Rigidbody rb;

    public Collider[] colliders;

    public LayerMask colorBoxesLayer;

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

        CheckDistance();
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
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime * speedMod);
    }

    void CheckDistance()
    {
        colliders = Physics.OverlapSphere(transform.position, checkRadius, colorBoxesLayer);       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ColorBoxes")
        {
            GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
}
