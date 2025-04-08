using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;

    public float speedMod, defaultSpeedModifier = 1f;

    public float checkRadius;

    public Material color;

    private PlayerControls playerControls;

    private Vector3 movement;

    private Rigidbody rb;

    public Collider[] colliders;

    public LayerMask colorBoxesLayer;

    public GameObject nearestBox;

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

        GetNearestBox();
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

    void GetNearestBox()
    {
        colliders = Physics.OverlapSphere(transform.position, checkRadius, colorBoxesLayer);

        foreach (Collider collider in colliders)
        {
            if(Vector3.Distance(transform.position, collider.transform.position) < checkRadius)
            {
                nearestBox = collider.gameObject;
            }
            else
            {
                nearestBox = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ColorBoxes")
        {
            GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
}
