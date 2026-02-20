using UnityEngine;

public class TMog : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform weaponHolder;
    [SerializeField] GameObject currentVisual;
    [SerializeField] GameObject selectedVisual;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            UpdateVisual();
        }
    }

    void UpdateVisual()
    {
        if(currentVisual.name == selectedVisual.name + "(Clone)")
        {
            Debug.Log("Visuals are equal");

            return;
        }

        GameObject currentWeapon = weaponHolder.GetChild(0).gameObject;
        Destroy(currentWeapon);

        GameObject newSelectedWeapon = Instantiate(selectedVisual, weaponHolder.position + selectedVisual.transform.position, selectedVisual.transform.rotation, weaponHolder);
        currentVisual = newSelectedWeapon;
    }
}