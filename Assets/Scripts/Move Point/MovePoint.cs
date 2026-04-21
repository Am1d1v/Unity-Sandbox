using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 movePosition;

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

        Physics.Raycast(mainCamera.transform.position, );
    }
}