using UnityEngine;

public class HitSplatters : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] ParticleSystem bloodVFX;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bloodVFX.Play();
        }
    }
}