using UnityEngine;

public class Chunks : MonoBehaviour
{
    public float slowMoveSpeedModifier, speedUpModifier;

    public bool isSlow;

    private void OnTriggerEnter(Collider other)
    {
        if(isSlow && other.gameObject.tag == "Player")
        {
            PlayerController.instance.speedMod = slowMoveSpeedModifier;
        }
        else if(!isSlow && other.gameObject.tag == "Player")
        {
            PlayerController.instance.speedMod = speedUpModifier;
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
