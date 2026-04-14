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

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point);
        }

        
    }

}