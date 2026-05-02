using UnityEngine;
using UnityEngine.UI;

public class SkinSelectUI : MonoBehaviour
{
    [Header("Skin Materials")]
    [SerializeField] Material[] materials;

    [Header("Select part button")]
    [SerializeField] Button selectHeadButton;

    [Header("Selected part to transform")]
    [SerializeField] GameObject selectedPart;

    void SetSkinMaterial(GameObject part, Material newMaterial)
    {
        part.GetComponent<MeshRenderer>().material = newMaterial;
    }
}