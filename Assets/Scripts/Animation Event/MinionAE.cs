using UnityEngine;

public class MinionAE : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.SetTrigger("fallDown");
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