using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelectUI : MonoBehaviour
{
    [Header("Skin Materials")]
    [SerializeField] Material[] materials;

    [Header("Select part button")]
    [SerializeField] Button selectHeadButton;
    [SerializeField] Button selectTorsoButton;
    [SerializeField] Button selectShouldersButton;


    [Header("Selected part to transform")]
    [SerializeField] GameObject selectedPart;

    void SetSkinMaterial(Material newMaterial)
    {
        if(selectedPart != null)
        {
            selectedPart.GetComponent<MeshRenderer>().material = newMaterial;
        }
    }

    public void SelectPart(GameObject part)
    {
        selectedPart = part;
    }
}