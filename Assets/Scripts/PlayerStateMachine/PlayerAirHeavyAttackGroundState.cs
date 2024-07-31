using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirHeavyAttackGroundState : PlayerState
{
    public PlayerAirHeavyAttackGroundState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {

        base.Enter();
        CinemachineShake.Instance.ShakeCamera(0.9f, 0.4f, 14f);
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
            stateMachine.ChangeState(player.idleState);

    }

    public override void Exit()
    {
        base.Exit();
    }
}
