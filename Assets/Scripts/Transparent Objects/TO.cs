using UnityEngine;
using UnityEngine.UIElements;

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
            raycasthit.collider.GetComponent<TransparentObject>().MakeTransparent();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
