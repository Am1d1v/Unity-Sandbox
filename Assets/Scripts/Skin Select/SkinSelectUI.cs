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
    [SerializeField] Button colorButtonPrefab;
    [SerializeField] Button[] colorButtons;
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

        SetSkinMaterial();
    }

    public void SelectColor(Color color)
    {
        selectedColor = color;
    }

    void SetColorButtons()
    {
        colorButtons = new Button[colors.Length];

        for(int i = 0; i < colors.Length; i++)
        {
            int index = i;

            Button colorBtn = Instantiate(colorButtonPrefab, colorsPanel);

            colorButtons[index] = colorBtn;

            colorBtn.image.color = colors[i];

            colorButtons[index].onClick.AddListener(() =>
            {
                SelectColor(colors[index]);
            });
        }
    }
}