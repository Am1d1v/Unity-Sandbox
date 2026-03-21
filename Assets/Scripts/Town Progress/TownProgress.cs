using UnityEngine;

public class TownProgress : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int townLevel;
    [SerializeField] int currentBuildingLevel;
    [SerializeField] GameObject[] guildBuilding;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            BuildGuild();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ResetTown();
        }
    }

    void TownLevelUp()
    {
        townLevel++;
    }

    void BuildGuild()
    {
        if (currentBuildingLevel > guildBuilding.Length - 1) return;

        currentBuildingLevel++;

        for(int i = 0; i < currentBuildingLevel; i++)
        {
            guildBuilding[i].SetActive(true);
        }

        TownLevelUp();
    }

    void ResetTown()
    {       
        for (int i = 0; i < currentBuildingLevel; i++)
        {
            guildBuilding[i].SetActive(false);
        }

        townLevel = 1;

        currentBuildingLevel = 0;
    }
}