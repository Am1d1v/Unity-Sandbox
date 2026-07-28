using UnityEngine;

public class TrineProtoPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePos;

    private void Update()
    {
        GetMousePos();
    }

    void GetMousePos()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;

        mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
    }
}