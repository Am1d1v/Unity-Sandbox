using System.Collections;
using UnityEngine;

public class ItemGrabAndDropItem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float rotationSpeed;

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

    public void SetDefaultRotationCO()
    {
        StartCoroutine(SetDefaultRotation());
    }

    IEnumerator SetDefaultRotation()
    {
        float xValue = transform.rotation.eulerAngles.x;
        float yValue = transform.rotation.eulerAngles.y;
        float zValue = transform.rotation.eulerAngles.z;

        while(transform.rotation.x != 0 && transform.rotation.y != 0 && transform.rotation.z != 0)
        {
            xValue = Mathf.MoveTowards(xValue, 0f, rotationSpeed * Time.deltaTime); 
            yValue = Mathf.MoveTowards(yValue, 0f, rotationSpeed * Time.deltaTime); 
            zValue = Mathf.MoveTowards(zValue, 0f, rotationSpeed * Time.deltaTime); 

            transform.rotation = Quaternion.Euler(xValue, yValue, zValue);

            yield return null;
        }
    }
}