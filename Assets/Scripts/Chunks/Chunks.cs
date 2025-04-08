using UnityEngine;

public class Chunks : MonoBehaviour
{
    public float slowMoveSpeedModifier;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerController.instance.speedMod = slowMoveSpeedModifier;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.instance.speedMod = PlayerController.instance.defaultSpeedModifier;
        }
    }
}
