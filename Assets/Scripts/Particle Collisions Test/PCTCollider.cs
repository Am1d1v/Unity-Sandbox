using UnityEngine;

public class PCTCollider : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Obstacle"))
        {
            
        }
    }
}