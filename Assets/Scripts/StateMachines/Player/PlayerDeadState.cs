using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        // toggle ragdoll EXTEND
        stateMachine.Ragdoll.ToggleRagdoll(true);
        stateMachine.Weapon.gameObject.SetActive(false);
        //stateMachine.Sound
        //stateMachine.UIManager.gameAnnounceLabel.color = Color.red;
        stateMachine.UIManager.SetGameAnnounceLabel("GAME OVER");
        stateMachine.UIManager.SetAnnounceLabel("You Failed!");
        stateMachine.UIManager.ChangeScene(0);
        //stateMachine.Hud.
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }
}
