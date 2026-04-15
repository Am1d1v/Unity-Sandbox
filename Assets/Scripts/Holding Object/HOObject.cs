using UnityEngine;

public class HOObject : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float yValueTrashold;

    private void Update()
    {
        if(transform.position.y <= yValueTrashold)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        HoldingObject.instance.SetItem(gameObject);
    }
}