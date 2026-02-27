using UnityEngine;

public class ItemGrabAndDropItem : MonoBehaviour
{
    private void Start()
    {
        SetRandomRotation();
    }

    void SetRandomRotation()
    {
        float randomXrotationValue = Random.Range(0f, 360f);
        float randomYrotationValue = Random.Range(0f, 360f);
        float randomZrotationValue = Random.Range(0f, 360f);

        transform.rotation = Quaternion.Euler(randomXrotationValue, randomYrotationValue, randomZrotationValue);
    }
}