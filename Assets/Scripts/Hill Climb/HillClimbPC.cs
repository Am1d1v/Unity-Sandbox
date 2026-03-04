using System;
using UnityEngine;

public class HillClimbPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] HillClimb selectedRock;

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

        }
    }

    public void SelectRock(HillClimb rock)
    {
        selectedRock = rock;
    }
}