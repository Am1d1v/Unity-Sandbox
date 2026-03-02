using UnityEngine;

public class GrabItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float mass;

    private void Start()
    {
        SetMass();
    }

    void SetMass()
    {
        mass = GetComponent<Rigidbody>().mass;
    }

    public float GetMass()
    {
        return mass;
    }
}