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

    public void Release()
    {
        GetComponent<Rigidbody>().isKinematic = false;

        transform.SetParent(null);
    }
    
    public void Grab(Transform parent)
    {
        GetComponent<Rigidbody>().isKinematic = true;

        transform.SetParent(parent);
    }

    
}