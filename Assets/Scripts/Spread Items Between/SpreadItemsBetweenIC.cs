using UnityEngine;

public class SpreadItemsBetweenIC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 posToMove;

    private void Update()
    {
        if(transform.position != posToMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, posToMove, moveSpeed * Time.deltaTime);
        }
    }

    public void SetPosition(Vector3 pos)
    {
        posToMove = pos;
    }
}