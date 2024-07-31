using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirHeavyAttackState : PlayerState
{
    private float lastTimeAttacked;
    public PlayerAirHeavyAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {

        base.Enter();
        player.SetVelocity(0, 10);
    }

    public override void Update()
    {
        base.Update();

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
