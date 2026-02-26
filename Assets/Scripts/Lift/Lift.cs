using System;
using System.Collections;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject movingPlatform;
    [SerializeField] GameObject selectedLevel;
    [SerializeField] GameObject[] levels;   
    [SerializeField] float moveSpeed;
    [SerializeField] bool isMoving;

    private void Start()
    {
        LiftLevelButton.onLiftLevelButtonClicked += SetSelectedLevel;
    }

    private void OnDestroy()
    {
        LiftLevelButton.onLiftLevelButtonClicked -= SetSelectedLevel;
    }
    private void Update()
    {
        if (selectedLevel != null && isMoving == false)
        {
            Move();
        }
    }

    void Move()
    {
        StartCoroutine(MoveCO());
    }

    void SetSelectedLevel(GameObject level)
    {
        if (selectedLevel == null)
        {
            selectedLevel = level;
        }
    }

    IEnumerator MoveCO()
    {
        while(movingPlatform.transform.position.y != selectedLevel.transform.position.y)
        {
            movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, new Vector3(0f, selectedLevel.transform.position.y, 0f), moveSpeed * Time.deltaTime);

            isMoving = true;

            yield return null;
        }

        isMoving = false;

        selectedLevel = null;
    }
}