using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizzardDyingState : EnemyState
{
    private readonly Enemy_Wizardo enemy;

    public WizzardDyingState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemyBase as Enemy_Wizardo;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetZeroVelocity();
        enemyBase.isDying = true;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}