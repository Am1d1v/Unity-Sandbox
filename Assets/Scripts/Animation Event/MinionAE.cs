using UnityEngine;

public class MinionAE : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.Play("Kneeling Down");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("standBack");
        }
    }
}