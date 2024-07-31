using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimPotionState : PlayerState
{
    public PlayerAimPotionState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetZeroVelocity();
        player.skill.throwSkill.DotsActive(true);
    }

    public override void Update()
    {
        base.Update();

        Vector2 direction = player.potionThrowSkill.AimDirection();
        int mouseDirection = direction.x < 0 ? -1 : 1;
        if (player.facingDir != mouseDirection)
        {
            player.Flip();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
            stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
