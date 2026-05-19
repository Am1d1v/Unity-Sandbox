using UnityEngine;

public class AIMovepoint : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePos;
    [SerializeField] Ray ray;

    private void Update()
    {
        SetMousePosition();
    }

    void SetMousePosition()
    {
        mousePos = Camera.main.WorldToScreenPoint(Input.mousePosition);

        RaycastHit hit;

        ray = new Ray(Camera.main.transform.position, mousePos);

        if (Physics.Raycast(Camera.main.transform.position, mousePos, out hit))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point);
        }

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;

    //    Gizmos.DrawRay(ray);
    //}
}