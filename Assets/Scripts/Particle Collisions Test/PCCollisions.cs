using System;
using System.Collections.Generic;
using UnityEngine;

public class PCCollisions : MonoBehaviour
{
    public static PCCollisions instance;

    [Header("Elements")]
    [SerializeField] ParticleSystem collisionParticles;
    [SerializeField] List<GameObject> collided = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            collisionParticles.Play();
        }
    }
}