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
    [SerializeField] Vector3 moveDirection;
    [SerializeField] bool isFeared;
    [SerializeField] LayerMask fearMask;

    private void Update()
    {
        CalculateDifference();

        //Move();

        //Look();

        if (fearDurationCounter > 0f)
        {
            isFeared = true;

            fearDurationCounter -= Time.deltaTime;
        }
        else
        {
            isFeared = false;
        }
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
        moveDirection = transform.forward;

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Look()
    {
        if (isFeared)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.LookAt(transform.position + moveDirection);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FearSpreader" && (difference >= fearTrashold && difference <= fearTrashold * -1))
        {            
         fearDurationCounter = fearDuration;
        }
    }
}