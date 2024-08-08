using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{

    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Alpha1) && player.inventory.Consume("Damage Potion"))
        {
            player.damage += 25;
            stateMachine.ChangeState(player.drinkingDamageState);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && player.skill.throwSkill.throwSkillUnlocked && player.inventory.Consume("Light Potion"))
        {
            stateMachine.ChangeState(player.aimPotionState);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && player.inventory.Consume("Speed Potion"))
        {
            player.moveSpeed += 5;
            stateMachine.ChangeState(player.drinkingSpeedState);
        }
        else if (Input.GetKeyDown(KeyCode.E) && !player.statsControl.IsMaxHealth() && player.inventory.Consume("Potion Heal"))
        {
            stateMachine.ChangeState(player.drinkingHealState);
        }

        if (Input.GetKeyDown(KeyCode.Q) && player.parrySkill.parryUnlocked)
            stateMachine.ChangeState(player.counterAttack);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.primaryAttack);

        if (!player.isGroundDetected())
            stateMachine.ChangeState(player.airState);

        if (Input.GetKeyDown(KeyCode.Space) && player.isGroundDetected())
            stateMachine.ChangeState(player.jumpState);

    }

    public override void Exit()
    {
        base.Exit();
    }
}
