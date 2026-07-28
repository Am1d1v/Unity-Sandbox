using UnityEngine;

public class TrineProtoPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector2 mousePos;

    private void Update()
    {
        GetMousePos();
    }

    void GetMousePos()
    {
        mousePos = Input.mousePosition;
    }
}