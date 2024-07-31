using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();

        player.DoubleJump();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.airAttackState);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
            stateMachine.ChangeState(player.airHeavyAttackState);

        if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
