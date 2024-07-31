using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirAttackState : PlayerState
{
    public PlayerAirAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {

        base.Enter();

    }

    public override void Update()
    {
        base.Update();

        if (player.isGroundDetected())
            stateMachine.ChangeState(player.idleState);

        if (!player.isGroundDetected() && player.isWallDetected())
            stateMachine.ChangeState(player.wallJumpState);

        if (triggerCalled)
            stateMachine.ChangeState(player.airState);

    }

    public override void Exit()
    {
        base.Exit();
    }
}
