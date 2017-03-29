using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public StateMachine fsm;

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Think() { }

}

public class StateMachine : MonoBehaviour
{

    public State state;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Think());
    }

    System.Collections.IEnumerator Think()
    {
        while (true)
        {
            state.Think();
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void ChangeState(State newState)
    {
        Debug.Log(this.GetType().Name + " changed to: " + newState.GetType().Name);
        if (state != null)
        {
            state.Exit();
        }
        state = newState;
        state.fsm = this;
        state.Enter();
    }
}

