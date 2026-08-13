using UnityEngine;

public class GridSetUpManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int width;
    [SerializeField] int length;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
    [SerializeField] float checkRadius;
    [SerializeField] Transform gridsHolder;
    [SerializeField] GameObject gridPrefab;
    [SerializeField] LayerMask obstacleLayer;

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

                Vector3 gridPosition = new Vector3(x * xOffset, 0f, y * yOffset);

                if (Physics.OverlapSphere(gridPosition, checkRadius, obstacleLayer).Length == 0)
                {
                    grid.transform.position = gridPosition;
                }
            }
        }
    }
}