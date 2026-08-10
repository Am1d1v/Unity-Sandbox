using UnityEngine;

public abstract class PSMPlayerBaseState : State
{
    protected PSMPlayerSM playerSM;

    public PSMPlayerBaseState(PSMPlayerSM playerSM)
    {
        this.playerSM = playerSM;
    }
}