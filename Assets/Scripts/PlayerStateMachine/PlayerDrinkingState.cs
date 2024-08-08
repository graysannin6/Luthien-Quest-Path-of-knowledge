using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrinkingState : PlayerState
{
    public PlayerDrinkingState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetZeroVelocity();
        player.isHealing = true;
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            player.health += 5;
            player.updateHealthBar(5);
            if (player.health > 100)
                player.health = 100;
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        player.isHealing = false;
    }
}