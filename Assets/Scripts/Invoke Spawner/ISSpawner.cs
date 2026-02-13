using UnityEngine;

public class ISSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material selectedMaterial;

    public void SelectSpawner()
    {
        meshRenderer.materials = new Material[] { selectedMaterial };
    }
    public void DeselectSpawner()
    {
        meshRenderer.materials = new Material[] { defaultMaterial };
    }
}