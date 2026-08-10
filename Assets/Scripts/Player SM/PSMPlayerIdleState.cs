using UnityEngine;

public class PSMPlayerIdleState : PSMPlayerBaseState
{
    public PSMPlayerIdleState(PSMPlayerSM playerSM) : base(playerSM)
    {

    }

    public override void Enter()
    {
        Debug.Log("Idle state entered");
    }

    public override void Exit()
    {
        Debug.Log("Idle state exited");
    }

    public override void Tick(float deltaTime)
    {
        
    }
}