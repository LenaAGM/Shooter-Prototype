using UnityEngine;

public sealed class StateMachine<T> where T : Controller
{
    private State<T> CurrentState;
    private T Controller;

    public StateMachine(T controller)
    {
        Controller = controller;
    }

    public void ApplyState<S>() where S : State<T>
    {
        DetachState(CurrentState);
        Controller.gameObject.AddComponent<S>();
        CurrentState = Controller.gameObject.GetComponent<S>();
        Controller.gameObject.GetComponent<S>().Controller = Controller;
    }

    private void DetachState(State<T> stateComp)
    {
        if (stateComp != null)
        {
            Object.Destroy(stateComp);
        }
    }
}