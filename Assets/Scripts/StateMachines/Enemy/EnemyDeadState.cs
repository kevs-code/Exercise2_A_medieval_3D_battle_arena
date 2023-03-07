using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Ragdoll.ToggleRagdoll(true);
        stateMachine.Weapon.gameObject.SetActive(false);
        GameObject.Destroy(stateMachine.Target);
        stateMachine.UIManager.SetAnnounceLabel("Victory!");
        //stateMachine.AnnouncerLabel.text = "Victory!";
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }
}
