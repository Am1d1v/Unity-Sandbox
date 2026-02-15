using UnityEngine;

public class RotationDif : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject target;
    [SerializeField] float difference;
    [SerializeField] float moveSpeed;
    [SerializeField] float fearTrashold;
    [SerializeField] float fearDuration;
    [SerializeField] float fearDurationCounter;
    [SerializeField] CharacterController characterController;
    [SerializeField] Vector2 moveDirection;
    [SerializeField] bool isFeared;
    [SerializeField] LayerMask fearMask;

    private void Start()
    {
        fearDurationCounter = fearDuration;
    }

    private void Update()
    {
        CalculateDifference();

        Move();
    }

    void CalculateDifference()
    {
        float dif = Mathf.Abs(transform.rotation.eulerAngles.y) - Mathf.Abs(target.transform.rotation.eulerAngles.y);

        if(dif > 180f)
        {           
            difference = 360 - transform.rotation.eulerAngles.y;
        }
        else
        {
            difference = dif;
        }
    }

    void Move()
    {
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}