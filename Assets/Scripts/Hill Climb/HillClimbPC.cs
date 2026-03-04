using System;
using UnityEngine;

public class HillClimbPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] int lastRockIndex;
    [SerializeField] int currentRockIndex;
    [SerializeField] Vector3 rockOffset;
    [SerializeField] Vector3 climbUp;
    [SerializeField] Transform rocksHolder;
    [SerializeField] HillClimb selectedRock;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator animator;

    [Header("Actions")]
    public static HillClimbPC instance;

    private void Awake()
    {
        instance = this; 
    }

    private void Update()
    {
        if (selectedRock)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DeselectRockAndHill();

            rb.isKinematic = false;

            currentRockIndex = 0;
        }       
    }

    public void SelectRock(HillClimb rock)
    {
        selectedRock = rock;

        rocksHolder = rock.transform.parent;

        lastRockIndex = rocksHolder.childCount;

        currentRockIndex = rock.RockIndex;
    }

    void Move()
    {
        if(Vector3.Distance(transform.position, selectedRock.transform.position) >= 0.1f)
        {
            rb.isKinematic = true;

            transform.position = Vector3.Slerp(transform.position, selectedRock.transform.position + rockOffset, moveSpeed * Time.deltaTime);

            if (currentRockIndex == lastRockIndex)
            {
                ClimbUp();

                DeselectRockAndHill();

                currentRockIndex = 0;
            }
        }
        
    }

    void DeselectRockAndHill()
    {
        selectedRock = null;

        rocksHolder = null;        
    }

    void ClimbUp()
    {
        transform.position = transform.forward * climbUp.z + new Vector3(0f, climbUp.y, 0f);

        animator.Play("Climb Up");       
    }

    void TurnOnRB()
    {
        rb.isKinematic = false;
    }
}