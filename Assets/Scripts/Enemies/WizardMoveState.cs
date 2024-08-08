using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizzardMoveState : EnemyState
{
    private readonly Enemy_Wizardo enemy;

    public WizzardMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemyBase as Enemy_Wizardo;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.isMoving = true;
        //enemy.
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);
        if (!enemy.isGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.attackState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        enemy.isMoving = false;
    }
}