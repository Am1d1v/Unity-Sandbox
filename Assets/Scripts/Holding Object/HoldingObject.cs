using UnityEngine;

public class HoldingObject : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePosition;
    [SerializeField] Ray ray;
    private void Update()
    {
        GetMousePosition();
    }

    void GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePosition = mousePos;

        if (Physics.Raycast(ray))
        {
            Debug.Log(ray);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(ray);
    }
}