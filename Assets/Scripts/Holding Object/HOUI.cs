using TMPro;
using UnityEngine;

public class HOUI : MonoBehaviour
{
    public static HOUI instance;

    [Header("Current Item")]
    [SerializeField] TMP_Text currentHoldingItem;

    private void Awake()
    {
        instance = this;
    }

    public void SetCurrentItemToSpawnText(string itemName)
    {
        currentHoldingItem.text = itemName;
    }
}