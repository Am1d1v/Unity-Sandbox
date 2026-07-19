using UnityEngine;

public class Rigify : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Rigidbody[] RBs;
    [SerializeField] float rbWeight;

    private void Start()
    {
        SetKinematic();

        SetRBWeight();
    }

    void SetKinematic()
    {
        foreach(Rigidbody rb in RBs)
        {
            rb.isKinematic = true;

            rb.useGravity = false;
        }
    }

    void SetRBWeight()
    {
        foreach (Rigidbody rb in RBs)
        {
            rb.mass = rbWeight;
        }
    }

    [ContextMenu("Unset RBs")]
    void UnsetKinematic()
    {
        foreach(Rigidbody rb in RBs)
        {
            rb.isKinematic = false;

            rb.useGravity = true;
        }
    }
}