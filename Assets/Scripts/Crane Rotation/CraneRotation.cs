using UnityEngine;

public class CraneRotation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject rotationTarget;

    private void Update()
    {
        LookAtTarget();
    }

    void LookAtTarget()
    {
        //transform.rotation = Quaternion.LookRotation(rotationTarget.transform.position);

        Quaternion lookDirection = Quaternion.LookRotation(rotationTarget.transform.position);

        if(transform.rotation != lookDirection)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, Time.deltaTime);
        }
    }
}