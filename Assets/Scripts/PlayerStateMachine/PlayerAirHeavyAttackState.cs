using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerAirHeavyAttackState : PlayerState
{
    private float yUpgrdableVelocity;
    public PlayerAirHeavyAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        yUpgrdableVelocity = Math.Abs(rb.velocity.y);
        player.SetVelocity(0, 10);
    }

    public override void Update()
    {
        base.Update();

        yUpgrdableVelocity += 0.25f;
        player.SetVelocity(0, yUpgrdableVelocity * -1);

        if (player.isGroundDetected())
        {
            stateMachine.ChangeState(player.airHeavyAttackGroundState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}
