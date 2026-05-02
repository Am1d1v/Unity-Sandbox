using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelectUI : MonoBehaviour
{
    [Header("Skin Materials")]
    [SerializeField] Color[] colors;

    [Header("Selected part to transform")]
    [SerializeField] GameObject selectedPart;
    [SerializeField] Color selectedColor;

    public void SetSkinMaterial(Material newMaterial)
    {
        if(selectedPart != null)
        {
            selectedPart.GetComponent<Material>().color = selectedColor;
        }
    }

    public void SelectPart(GameObject part)
    {
        selectedPart = part;
    }

    void SetMaterialButtons()
    {

    }
}