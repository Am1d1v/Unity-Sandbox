using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePosition;
    [SerializeField] Vector3 lookDirection;

    private void Update()
    {
        GetMousePosition();
    }

    void GetMousePosition()
    {      
        mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            lookDirection = hit.point;
            lookDirection.y = 0f;
        }
    }
}