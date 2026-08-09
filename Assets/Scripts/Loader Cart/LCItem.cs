using UnityEngine;

public class LCItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float xSizeBordersmin;
    [SerializeField] float xSizeBordersmax;
    [SerializeField] float ySizeBordersmin;
    [SerializeField] float ySizeBordersmax;
    [SerializeField] float zSizeBordersmin;
    [SerializeField] float zSizeBordersmax;
    [field: SerializeField] public int totalValue { get; private set; }

    private void Start()
    {
        ConfigureItem();
    }

    void ConfigureItem()
    {
        float selectedXSize = Random.Range(xSizeBordersmin, xSizeBordersmax);
        float selectedYSize = Random.Range(ySizeBordersmin, ySizeBordersmax);
        float selectedZSize = Random.Range(zSizeBordersmin, zSizeBordersmax);

        totalValue = Mathf.RoundToInt(selectedXSize + selectedYSize + selectedZSize);

        transform.localScale = new Vector3(selectedXSize, selectedYSize, selectedZSize);
    }
}