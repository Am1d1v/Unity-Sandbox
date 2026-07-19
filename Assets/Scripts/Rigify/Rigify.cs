using UnityEngine;

public class Rigify : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Rigidbody[] RBs;

    private void Start()
    {
        SetKinematic();
    }

    void SetKinematic()
    {
        foreach(Rigidbody rb in RBs)
        {
            rb.isKinematic = true;
        }
    }
}