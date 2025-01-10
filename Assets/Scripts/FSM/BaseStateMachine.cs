using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine<T> : MonoBehaviour
{
    public delegate void OnStateChange();
    public OnStateChange onStateChange;
    protected Dictionary<T, BaseState<T>> dictionaryStates;
    protected BaseState<T> currentState;
    public BaseState<T> CurrentState { get { return currentState; } }

    protected virtual void LoadStates()
    {

    }

    public virtual void SwitchState(T type)
    {
        currentState.OnExit(this);
        currentState = dictionaryStates[type];
        currentState.OnEnter(this);

        onStateChange?.Invoke();
    }
}
