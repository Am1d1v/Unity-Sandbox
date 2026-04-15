using UnityEngine;

public class HOObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        HoldingObject.instance.SetItem(gameObject);
    }
}