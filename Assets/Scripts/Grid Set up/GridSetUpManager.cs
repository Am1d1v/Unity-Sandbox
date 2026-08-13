using UnityEngine;

public class GridSetUpManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int width;
    [SerializeField] int length;
    [SerializeField] Transform gridsHolder;
    [SerializeField] GameObject gridPrefab;

    private void Start()
    {
        SetGrid();
    }

    void SetGrid()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < length; y++)
            {
                GameObject grid = Instantiate(gridPrefab, transform.position, Quaternion.identity, gridsHolder);

                grid.transform.localPosition = new Vector3(x, 0f, y);
            }
        }
    }
}