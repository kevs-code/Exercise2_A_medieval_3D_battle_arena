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
        Scene scene = SceneManager.GetActiveScene();
        stateMachine.Ragdoll.ToggleRagdoll(true);
        stateMachine.Weapon.gameObject.SetActive(false);
        GameObject.Destroy(stateMachine.Target);
        int count = SceneManager.sceneCountInBuildSettings;
        if (scene.buildIndex == count - 1)
        {
            stateMachine.UIManager.SetGameAnnounceLabel("YOU WON THE GAME!");
        }
        stateMachine.UIManager.SetAnnounceLabel("You Win!");
        stateMachine.UIManager.ChangeScene(scene.buildIndex);
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }
}
