using System.Collections.Generic;
using UnityEngine;

public class HitSplatters : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] ParticleSystem bloodVFX;
    [SerializeField] List<ParticleCollisionEvent> bloodCollisionsEvent = new List<ParticleCollisionEvent>();
    [SerializeField] List<Vector3> bloodPoints = new List<Vector3>();
    [SerializeField] GameObject bloodPrefab;

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
        
        for(int i = 0; i < bloodPoints.Count; i++)
        {
            Instantiate(bloodPrefab, bloodPoints[i], Quaternion.identity);
        }
    }   
}