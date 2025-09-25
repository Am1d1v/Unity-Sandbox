using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    [SerializeField] Material defaultMaterial, transparentMaterial;

    [SerializeField] MeshRenderer meshRenderer;
    public void MakeTransparent()
    {
        meshRenderer.material = transparentMaterial;
    }
}
