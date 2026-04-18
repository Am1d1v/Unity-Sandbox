using UnityEngine;

[CreateAssetMenu(fileName = "LootSO", menuName = "Scriptable Objects/LootSO")]
public class LootSO : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] Color[] colors;
    [SerializeField] float minLength;
    [SerializeField] float maxLength;
    public Color[] Colors => colors;
    public float MinLength => minLength;
    public float MaxLength => maxLength;
}
