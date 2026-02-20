using System.Collections.Generic;
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
        weaponHolder.GetChild(0).gameObject.SetActive(false);

        Instantiate(selectedVisual, weaponHolder.position + selectedVisual.transform.position, selectedVisual.transform.rotation, weaponHolder);
    }
}