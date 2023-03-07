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
        stateMachine.UIManager.SetAnnounceLabel("You Failed!");
        //stateMachine.Hud.
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }
}
