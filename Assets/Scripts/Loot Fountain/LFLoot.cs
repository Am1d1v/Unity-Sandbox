using UnityEngine;

public class LFLoot : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] LootSO LootSO;
    [SerializeField] MeshRenderer lootVisual;
    [SerializeField] float length;

    private void Start()
    {
        ConfigureLoot();
    }

    void ConfigureLoot()
    {
        int selectedMaterialIndex = Random.Range(0, LootSO.Materials.Length);

        lootVisual.material = LootSO.Materials[selectedMaterialIndex];

        length = Random.Range(LootSO.MinLength, LootSO.MaxLength);

        transform.localScale = new Vector3(length, transform.localScale.y, transform.localScale.z);
    }
}