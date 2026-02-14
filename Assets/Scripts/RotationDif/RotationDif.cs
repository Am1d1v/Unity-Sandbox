using UnityEngine;

public class RotationDif : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject target;
    [SerializeField] float difference;

    private void Update()
    {
        CalculateDifference();
    }

    void CalculateDifference()
    {
        float dif = Mathf.Abs(transform.rotation.eulerAngles.y) - Mathf.Abs(target.transform.rotation.eulerAngles.y);

        if(dif > 180f)
        {           
            difference = 360 - transform.rotation.eulerAngles.y;
        }
        else
        {
            difference = dif;
        }
    }
}