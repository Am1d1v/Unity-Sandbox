using UnityEngine;

[CreateAssetMenu(fileName = "GridDataSO", menuName = "Scriptable Objects/GridDataSO")]
public class GridDataSO : ScriptableObject
{
    [Header("Settings")]
    public Material gridMaterial;
}
