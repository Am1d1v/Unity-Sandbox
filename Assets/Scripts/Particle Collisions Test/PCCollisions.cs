using UnityEngine;

public class PCCollisions : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] ParticleSystem collisionParticles;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            collisionParticles.Play();
        }
    }
}