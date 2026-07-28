using Unity.Cinemachine;
using UnityEngine;

public class TrineProtoPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Vector3 mousePos;
    [SerializeField] Vector3 mousePosViewport;
    [SerializeField] Vector3 raycastHit;
    [SerializeField] Vector3 holdingObjectStartPos;
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] float rayLength;
    [SerializeField] float objectMoveSpeed;
    [SerializeField] float objectDragStrength;

    [Header("Elements")]
    [SerializeField] GameObject holdingObject;
    [SerializeField] Camera camera;
    [SerializeField] CinemachineCamera cincamera;


    private void Update()
    {
        GetMousePos();

        if (Input.GetMouseButtonDown(0))
        {
            GetRaycast();
        }
        else if (Input.GetMouseButtonDown(1) && holdingObject != null)
        {
            DropObject();
        }

        if(holdingObject != null)
        {
            MoveHoldingObject();
        }
    }

    void GetMousePos()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = rayLength;

        mousePos = camera.ScreenToWorldPoint(mousePosition);

        mousePosViewport = Camera.main.ScreenToViewportPoint(mousePosition);
    }

    void DropObject()
    {
        holdingObject.GetComponent<Rigidbody>().isKinematic = false;

        holdingObject = null;
    }

    void MoveHoldingObject()
    {
        //holdingObject.transform.position = holdingObjectStartPos + new Vector3(mousePosViewport.x, mousePosViewport.y, 0f);

        //holdingObject.transform.position = Vector3.MoveTowards(holdingObject.transform.position, new Vector3(mousePosViewport.x, mousePosViewport.y, 0f) * objectDragStrength, objectMoveSpeed * Time.deltaTime);

        holdingObject.transform.position = Vector3.MoveTowards(holdingObject.transform.position, new Vector3(mousePos.x, mousePos.y, 0f), objectMoveSpeed * Time.deltaTime);
    }

    void GetRaycast()
    {
        RaycastHit hit;
      
        if(Physics.Raycast(Camera.main.transform.position, new Vector3(mousePos.x, mousePos.y, rayLength), out hit, rayLength, obstacleLayer))
        {
            holdingObject = hit.collider.gameObject;

            holdingObjectStartPos = holdingObject.transform.position;

            holdingObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(camera.transform.position, new Vector3(mousePos.x, mousePos.y, rayLength));
    }
}