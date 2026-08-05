using System.Collections.Generic;
using UnityEngine;

public class HitSplatters : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] ParticleSystem bloodVFX;
    [SerializeField] List<ParticleCollisionEvent> bloodCollisionsEvent = new List<ParticleCollisionEvent>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bloodVFX.Play();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        int splattersCount = bloodVFX.GetSafeCollisionEventSize();

        Debug.Log(splattersCount);
    }   
}