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

    [Header("Collor buttons")]
    [SerializeField] Button colorButton;
    [SerializeField] Transform colorsPanel;

    private void Start()
    {
        SetColorButtons();
    }

    public void SetSkinMaterial()
    {
        if(selectedPart != null)
        {
            selectedPart.GetComponent<MeshRenderer>().materials[0].color = selectedColor;
        }
    }

    public void SelectPart(GameObject part)
    {
        selectedPart = part;
    }

    void SetColorButtons()
    {
        for(int i = 0; i < colors.Length; i++)
        {
            Button colorBtn = Instantiate(colorButton, colorsPanel);
        }
    }
}