using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 movePosition;
    [SerializeField] Vector3 rayDirection;

    [Header("Elements")]
    [SerializeField] Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        MoveRay();
    }

    void MoveRay()
    {      
        RaycastHit hit;

        rayDirection = Camera.main.ScreenPointToRay(Input.mousePosition).direction;

        Ray ray = new Ray(mainCamera.transform.position, rayDirection);

        if(Physics.Raycast(ray, out hit))
        {
            movePosition = hit.point;
        }
       
        Debug.DrawRay(mainCamera.transform.position, rayDirection, Color.red);
    }
}