using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyDeadState : EnemyBaseState
{
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {

        stateMachine.Ragdoll.ToggleRagdoll(true);
        stateMachine.Weapon.gameObject.SetActive(false);

        Targeter targeter = stateMachine.Player.gameObject.GetComponentInChildren<Targeter>();
        //targeter.Cancel();
        targeter.RemoveTargetWithDelay(stateMachine.Target);//move this?
        //GameObject.Destroy(stateMachine.Target);

        //stateMachine.Target.DestroyTarget();
        // Player won!

        stateMachine.RoundManager.PlayerWonFight();
        
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }
}
