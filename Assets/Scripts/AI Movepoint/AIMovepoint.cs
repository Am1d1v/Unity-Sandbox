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
        // mousePos = Input.mousePosition.normalized;
        // mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 10f);
    }
}