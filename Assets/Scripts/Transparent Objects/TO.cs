using UnityEngine;

public class TO : MonoBehaviour
{
    [SerializeField] float distance;

    [SerializeField] LayerMask objectMask;

    // Update is called once per frame
    void Update()
    {
        CastRay();
    }

    void CastRay()
    {
        RaycastHit[] raycasts = Physics.RaycastAll(transform.position, transform.forward, distance, objectMask);

        foreach(RaycastHit raycasthit in raycasts)
        {
            Debug.Log(raycasthit.collider.name);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position, transform.forward);
    }
}
