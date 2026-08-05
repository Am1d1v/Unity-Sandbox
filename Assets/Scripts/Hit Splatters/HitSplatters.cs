using System.Collections.Generic;
using UnityEngine;

public class HitSplatters : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] ParticleSystem bloodVFX;
    [SerializeField] List<ParticleCollisionEvent> bloodCollisionsEvent = new List<ParticleCollisionEvent>();
    [SerializeField] List<Vector3> bloodPoints = new List<Vector3>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bloodPoints.Clear();

            bloodVFX.Play();
        }
    }

    private void OnParticleCollision(GameObject other)
    {       
        int splattersEventsCount = bloodVFX.GetCollisionEvents(other, bloodCollisionsEvent);

        for(int i = 0; i < splattersEventsCount; i++)
        {
            bloodPoints.Add(bloodCollisionsEvent[i].intersection);
        }
    }   
}