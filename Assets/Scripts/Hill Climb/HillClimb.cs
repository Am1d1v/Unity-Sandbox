using Unity.VisualScripting;
using UnityEngine;

public class HillClimb : MonoBehaviour
{
    private void OnMouseDown()
    {
        HillClimbPC.instance.SelectRock(this);
    }

}