using UnityEngine;

public class HOObject : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float yValueThreshold;

    private void Update()
    {
        if(transform.position.y <= yValueThreshold)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        HoldingObject.instance.SetItem(gameObject);
    }
}