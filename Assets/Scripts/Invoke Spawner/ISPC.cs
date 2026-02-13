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

    private void Update()
    {
        Move();

        Rotate();

        SpawnersCheck();

        if (Input.GetKeyDown(KeyCode.LeftShift) && detectedSpawners.Count > 0)
        {
            SelectSpawner();
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
        }
    }

    void SelectSpawner()
    {
        detectedSpawners[currentSelectedSpawnerIndex].GetComponent<ISSpawner>().SelectSpawner();
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
    }


}