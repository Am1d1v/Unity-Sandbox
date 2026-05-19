using UnityEngine;

public class AIMovepoint : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePos;


    private void Update()
    {
        SetMousePosition();
    }

    void SetMousePosition()
    {
        mousePos = new Vector3(Camera.main.transform.position.x, 0f, Camera.main.transform.position.y);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, mousePos, out hit))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point);
        }

    }
}