using UnityEngine;

public class DGSUGridManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int width;
    [SerializeField] int length;
    [SerializeField] GameObject gridPrefab;

    private void Start()
    {
        SetGrid();
    }

    void SetGrid()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < length; j++)
            {
                GameObject grid = Instantiate(gridPrefab, gridPrefab.transform.position, Quaternion.identity, transform);

                grid.transform.localPosition = new Vector3(i, 0f, j);
            }
        }
    }
}