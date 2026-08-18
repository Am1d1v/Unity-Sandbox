using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class CRPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] public float rotationSpeed; 
    [SerializeField] Vector2 rotationInput;

    [Header("Input Actions")]
    [SerializeField] InputActionReference RotationInputAction;

    private void Start()
    {
        //LoadData();
    }

    private void Update()
    {
        //RotateMethod();
        //RotateMouse();
        //RotateTransform();
        RotateTransformMouse();

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadData();
        }
        if (Input.GetMouseButtonDown(0))
        {
            rotationSpeed++;
        }
    }

    void RotateMethod()
    {
        rotationInput.x = RotationInputAction.action.ReadValue<Vector2>().x;

        transform.Rotate(new Vector2(0f, rotationInput.x) * rotationSpeed * Time.deltaTime);
    }
    
    void RotateMouse()
    {
        rotationInput.x = Input.GetAxisRaw("Mouse X");

        transform.Rotate(new Vector2(0f, rotationInput.x) * rotationSpeed * Time.deltaTime);
    }

    void RotateTransform()
    {
        rotationInput.x = RotationInputAction.action.ReadValue<Vector2>().x;

        if (rotationInput.x == 0) return;

        Quaternion currentRotation = transform.rotation;

        Quaternion targetRotation = Quaternion.LookRotation(rotationInput.x * transform.right);

        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    
    
    }
    
    void RotateTransformMouse()
    {
        rotationInput.x = Input.GetAxisRaw("Mouse X");

        if (rotationInput.x == 0) return;

        Quaternion currentRotation = transform.rotation;

        Quaternion targetRotation = Quaternion.LookRotation(rotationInput.x * transform.right);

        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void SaveData()
    {
        string dataPath = Application.dataPath + "/Data.txt";

        string data = JsonUtility.ToJson(this, true);

        File.WriteAllText(dataPath, data);

        Debug.Log("Saved");

    }

    void LoadData()
    {
        string dataPath = Application.dataPath + "/Data.txt";

        string playerData = File.ReadAllText(dataPath);

        JsonUtility.FromJsonOverwrite(playerData, this);

        Debug.Log("Loaded");
    }
}