using UnityEngine;

public class DGSUGrid : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GridDataSO gridData;
    [SerializeField] DGSUGridType gridType;
    [SerializeField] MeshRenderer gridMR;

    private void Start()
    {
        ConfigureGrid(gridType);
    }

    void ConfigureGrid(DGSUGridType type)
    {
        gridMR.material = gridData.gridMaterial;
    }

    private void OnMouseDown()
    {
        Debug.Log(gridData.gridMaterial);
    }
}