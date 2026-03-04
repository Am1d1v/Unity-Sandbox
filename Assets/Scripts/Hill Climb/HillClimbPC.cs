using System;
using UnityEngine;

public class HillClimbPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float hangingDuration;
    [SerializeField] float hangingDurationCounter;
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

        hangingDurationCounter = hangingDuration;
    }

    private void Update()
    {
        if (selectedRock)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StopHangingProcess();
        }     
        
        if(selectedRock != null)
        {
            hangingDurationCounter -= Time.deltaTime;
        }

        if(hangingDurationCounter <= 0f)
        {
            StopHangingProcess();

            hangingDurationCounter = hangingDuration;
        }
    }

    public void SelectRock(HillClimb rock)
    {
        selectedRock = rock;

        rocksHolder = rock.transform.parent;

        lastRockIndex = rocksHolder.childCount;

        currentRockIndex = rock.RockIndex;

        hangingDurationCounter = hangingDuration;
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
        transform.localPosition += transform.forward * climbUp.z + new Vector3(0f, climbUp.y, 0f);

        animator.Play("Climb Up");       
    }

    void TurnOnRB()
    {
        rb.isKinematic = false;
    }

    void StopHangingProcess()
    {
        DeselectRockAndHill();

        rb.isKinematic = false;

        currentRockIndex = 0;
    }
}