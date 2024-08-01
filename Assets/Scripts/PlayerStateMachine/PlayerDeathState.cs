using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.isDying = true;
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
