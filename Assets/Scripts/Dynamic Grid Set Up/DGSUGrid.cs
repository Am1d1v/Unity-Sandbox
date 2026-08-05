using UnityEngine;

public class DGSUGrid : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GridDataSO gridData;

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Data");
    }
}