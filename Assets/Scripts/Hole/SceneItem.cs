using UnityEngine;

public class SceneItem : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.useGravity = true;
    }
}