using UnityEngine;
using UnityEngine.InputSystem;

public class PSPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float detectionRange;
    [SerializeField] float moveSpeed;
    [SerializeField] int selectedPlatformSpawnPosition;
    [SerializeField] Vector3 detectionOffset;
    [SerializeField] Vector3 moveInput;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Vector3[] platformPositions;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] LayerMask platformLayer;

    [Header("Input Actions")]
    [SerializeField] InputActionReference MoveActionInput;

    private void Start()
    {
        CreatePlatform();

        
    }

    private void Update()
    {        
        if (MoveActionInput.action.WasPerformedThisFrame())
        {
            GetMoveInputValue();
        }

        Move();

        if (Input.GetKeyDown(KeyCode.P))
        {
            CreatePlatform();
        }

        DetectPlatform();
    }

    void CreatePlatform()
    {
        selectedPlatformSpawnPosition = Random.Range(0, platformPositions.Length);

        Instantiate(platformPrefab, transform.position + platformPositions[selectedPlatformSpawnPosition], Quaternion.identity);
    }

    void DetectPlatform()
    {
        if(Physics.CheckBox(transform.position + platformPositions[selectedPlatformSpawnPosition], Vector3.one * detectionRange, Quaternion.identity, platformLayer))
        {
            Debug.Log("Platform");
        }
    }

    void GetMoveInputValue()
    {
        moveInput.x = MoveActionInput.action.ReadValue<Vector2>().x;
        moveInput.z = MoveActionInput.action.ReadValue<Vector2>().y;

        targetPosition = transform.position + moveInput;
    }

    void Move()
    {      
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireCube(transform.position + platformPositions[selectedPlatformSpawnPosition], Vector3.one * detectionRange);
    }
}