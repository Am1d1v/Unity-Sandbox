using UnityEngine;

public class PSMPlayerSM : PSMStateMachine
{
    [Header("Elements")]
    [field: SerializeField] public Animator Animator { get; private set; }

    private void Start()
    {
        SwitchState(new PSMPlayerIdleState(this));
    }
}
