using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float movespeed = 1f;

    public float speedMod, defaultSpeedModifier;

    public float checkRadius;

    public float fallingTimer;
    private float fallingTimerCounter;

    public bool isFalling;

    public Material color;

    private PlayerControls playerControls;

    private Vector3 movement;

    private Rigidbody rb;

    public Collider[] colliders;

    public LayerMask colorBoxesLayer, groundLayer;

    public GameObject nearestBox;

    private void Awake()
    {
        instance = this;

        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        rb = GetComponent<Rigidbody>();

        defaultSpeedModifier = speedMod;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fallingTimerCounter = fallingTimer;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        GetNearestBox();

        CharacterFallingState();
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

    void CharacterFallingState()
    {
        Collider[] collision = Physics.OverlapSphere(transform.position, 1f, groundLayer);

        if(collision.Length == 0)
        {
            isFalling = true;

            if (isFalling)
            {
                fallingTimerCounter -= Time.deltaTime;
                if(fallingTimerCounter <= 0 && isFalling)
                {
                    Debug.Log("Falling animation");
                }
            }           
        }
        else
        {
            isFalling = false;

            fallingTimerCounter = fallingTimer;

            Debug.Log("Running animation");
        }
    }
}
