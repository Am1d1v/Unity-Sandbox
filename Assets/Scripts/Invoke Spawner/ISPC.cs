using System.Collections.Generic;
using UnityEngine;

public class ISPC : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] int currentSelectedSpawnerIndex;
    [SerializeField] LayerMask spawnerMask;
    [SerializeField] CharacterController characterController;
    [SerializeField] SphereCollider detectionCollider;
    [SerializeField] List<Collider> detectedSpawners = new List<Collider>();

    [Header("Elements")]
    [SerializeField] ISSpawner selectedSpawner;

    private void Update()
    {
        Move();

        Rotate();

        SpawnersCheck();

        if (detectedSpawners.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && currentSelectedSpawnerIndex < detectedSpawners.Count)
            {
                SelectSpawner();               
            }       
        }
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        characterController.Move(transform.forward * moveInput);
    }
    void Rotate()
    {
        float rotationInput = Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Rotate(new Vector3(0f, rotationInput, 0f));
    }

    void SpawnersCheck()
    {
        Collider[] spawners = Physics.OverlapSphere(transform.position, detectionCollider.radius, spawnerMask);

        if(spawners.Length > 0)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                if (detectedSpawners.Contains(spawners[i]))
                {
                    continue;
                }
                else
                {
                    detectedSpawners.Add(spawners[i]);
                }
            }
            
        }
        else
        {
            DeselectAllSpawners();

            detectedSpawners.Clear();

            currentSelectedSpawnerIndex = 0;
        }
    }

    void SelectSpawner()
    {
        DeselectAllSpawners();

        selectedSpawner = detectedSpawners[currentSelectedSpawnerIndex].GetComponent<ISSpawner>();

        selectedSpawner.SelectSpawner();

        currentSelectedSpawnerIndex++;

        if (currentSelectedSpawnerIndex > detectedSpawners.Count - 1)
        {
            currentSelectedSpawnerIndex = 0;
        }
    }
    
    void DeselectSpawner()
    {
        detectedSpawners[currentSelectedSpawnerIndex].GetComponent<ISSpawner>().DeselectSpawner();
    }
    
    void DeselectAllSpawners()
    {
        foreach(Collider spawnerCollider in detectedSpawners)
        {
            ISSpawner spawner = spawnerCollider.GetComponent<ISSpawner>();

            spawner.DeselectSpawner();
        }

        selectedSpawner = null;
    }


}