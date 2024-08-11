using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public StateMachine stateMachine;
    public Monster monster;
    public Camera camera;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();


}


