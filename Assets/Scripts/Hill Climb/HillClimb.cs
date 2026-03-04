using Unity.VisualScripting;
using UnityEngine;

public class HillClimb : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int index;
    public int RockIndex => index;

    private void OnMouseDown()
    {
        HillClimbPC.instance.SelectRock(this);
    }

}