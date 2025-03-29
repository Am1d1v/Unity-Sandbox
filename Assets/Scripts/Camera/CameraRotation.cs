using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public Camera mainCamera;

    public GameObject objectToFollow;

    public int currentAngle;

    public float targetRotation;

    public float rotateSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.transform.position + new Vector3(0f, 3.6f, -6f);

        //if (Keyboard.current.qKey.wasPressedThisFrame)
        //{
        //    mainCamera.transform.eulerAngles += new Vector3(0f, 30f, 0f);
        //} else if (Keyboard.current.eKey.wasPressedThisFrame)
        //{
        //    mainCamera.transform.eulerAngles += new Vector3(0f, -30f, 0f);
        //}

        // Camera rotation
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentAngle++;

            if (currentAngle >= 4)
            {
                currentAngle = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentAngle--;

            if (currentAngle < 0)
            {
                currentAngle = 3;
            }
        }

        targetRotation = (90f * currentAngle);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(45f, targetRotation, 0f), rotateSpeed * Time.deltaTime);
    }
}
