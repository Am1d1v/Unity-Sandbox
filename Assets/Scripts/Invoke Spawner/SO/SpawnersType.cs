using UnityEngine;

[CreateAssetMenu(fileName = "SpawnersType", menuName = "Scriptable Objects/SpawnersType")]
public class SpawnersType : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material selectedMaterial;

    public Material DefaultMaterial => defaultMaterial;
    public Material SelectedMaterial => selectedMaterial;
}
