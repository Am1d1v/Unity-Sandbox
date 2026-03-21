using UnityEngine;

public class TownProgress : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int townLevel;
    [SerializeField] int currentBuildingLevel;
    [SerializeField] GameObject[] guildBuilding;

    void TownLevelUp()
    {
        townLevel++;
    }
}