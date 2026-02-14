using UnityEngine;

public class RotationDif : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject target;
    [SerializeField] float difference;

    private void Update()
    {
        CalculateDifference();
    }

    void CalculateDifference()
    {
        dif = transform.rotation.eulerAngles.y - target.transform.rotation.eulerAngles.y;
    }
}