using UnityEngine;

public class HoldingObject : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePosition;
    private void Update()
    {
        GetMousePosition();
    }

    void GetMousePosition()
    {
        mousePosition = Input.mousePosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Gizmos.DrawRay(Camera.main.transform.position, );
    }
}