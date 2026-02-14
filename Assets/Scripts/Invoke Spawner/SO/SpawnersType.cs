using UnityEngine;

[CreateAssetMenu(fileName = "SpawnersType", menuName = "Scriptable Objects/SpawnersType")]
public class SpawnersType : ScriptableObject
{
    [Header("Settings")]
    public Material defaultMaterial;
    public Material selectedMaterial;
}
