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
        if (Input.GetKeyUp(KeyCode.M) && selectedLevel != null)
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
        while(movingPlatform.transform.position.y < selectedLevel.transform.position.y)
        {
            movingPlatform.transform.position += new Vector3(0f, movingPlatform.transform.position.y * moveSpeed * Time.deltaTime, 0f);

            yield return null;
        }

        selectedLevel = null;
    }
}