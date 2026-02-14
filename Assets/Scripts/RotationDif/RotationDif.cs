using UnityEngine;

public class RotationDif : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject target;
    [SerializeField] float difference;
    [SerializeField] float dif;

    private void Update()
    {
        CalculateDifference();
    }

    void CalculateDifference()
    {
        dif = Mathf.Abs(transform.rotation.eulerAngles.y) - Mathf.Abs(target.transform.rotation.eulerAngles.y);

        //difference = dif;

        //difference = 360 - dif;

        if(dif > 180)
        {
            
            difference = transform.rotation.eulerAngles.y;
        }
        else
        {
            difference = dif;
        }
    }
}