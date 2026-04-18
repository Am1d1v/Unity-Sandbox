using UnityEngine;

[CreateAssetMenu(fileName = "LootSO", menuName = "Scriptable Objects/LootSO")]
public class LootSO : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] Material[] materials;
    [SerializeField] float minLength;
    [SerializeField] float maxLength;
    public Material[] Materials => materials;
    public float MinLength => minLength;
    public float MaxLength => maxLength;
}