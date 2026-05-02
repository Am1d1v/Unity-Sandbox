using UnityEngine;

public class SkinSelect : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject torso;
    [SerializeField] GameObject head;
    [SerializeField] GameObject[] shoulders;
    [SerializeField] Material[] materials;

    void SetSkinMaterial(GameObject part, Material newMaterial)
    {
        part.GetComponent<MeshRenderer>().material = newMaterial;
    }
}