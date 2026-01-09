using UnityEngine;

public class MinionAE : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("standBack");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("fallDown");
        }
    }
}