using System.Collections;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject movingPlatform;
    [SerializeField] GameObject selectedLevel;
    [SerializeField] GameObject[] levels;
    [SerializeField] int selectedLevelIndex;
    [SerializeField] float moveSpeed;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && selectedLevel != null)
        {
            Move();
        }
    }

    void Move()
    {
        StartCoroutine(MoveCO());
    }

    IEnumerator MoveCO()
    {
        while(movingPlatform.transform.position.y != selectedLevel.transform.position.y)
        {
            movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, new Vector3(0f, selectedLevel.transform.position.y, 0f), moveSpeed * Time.deltaTime);

            yield return null;
        }

        selectedLevel = null;
    }
}