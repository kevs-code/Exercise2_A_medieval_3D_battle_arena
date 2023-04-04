using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinState : PlayerBaseState
{
    private readonly int WinHash = Animator.StringToHash("Sword1h_Victory_4");
    //impact = sword_hit_l_1
    private const float CrossFadeDuration = 0.1f;
    //private float duration = 1f;

    public PlayerWinState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(WinHash, CrossFadeDuration);//10secs roughly
    }

    public override void Tick(float deltaTime)
    {
        /*
        Move(deltaTime);

        duration -= deltaTime;

        if (duration <= 8f)
        {
            FixBadAnimation
        }
        */
    }

    public override void Exit()
    {
        //ReturnToLocomotion();// still causes stack overflow with reset
    }
}