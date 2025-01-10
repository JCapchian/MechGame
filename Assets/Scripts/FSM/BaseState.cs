using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public abstract class BaseState<T>
{
    public abstract T Type { get; }
    /// <summary>Ejecuta cuando entra</summary>
    public abstract void OnEnter(BaseStateMachine<T> baseStateMachine);
    /// <summary>Ejecuta cuando sale</summary>
    public abstract void OnExit(BaseStateMachine<T> baseStateMachine);
    /// <summary>Ejecuta dentro de un Update</summary>
    public abstract void OnUpdate(BaseStateMachine<T> baseStateMachine);
    /// <summary>Ejecuta dentro de un FixedUpdate</summary>
    public abstract void OnFixedUpdate(BaseStateMachine<T> baseStateMachine);
    /// <summary>Ejecuta dentro de un LateUpdate</summary>
    public abstract void OnLateUpdate(BaseStateMachine<T> baseStateMachine);
}