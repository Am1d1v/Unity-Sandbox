using UnityEngine;

public class PSMStateMachine : MonoBehaviour
{
    [field: SerializeField] protected State currentState;

    private void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }

    protected void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
}