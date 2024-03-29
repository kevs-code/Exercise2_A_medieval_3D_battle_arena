using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    protected SoundManager sound;
    
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        this.sound = stateMachine.SoundManager;
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        if (Vector3.zero != motion)
        {
            if (stateMachine.Targeter.CurrentTarget != null)
            {
                sound.feetPlayer.pitch = 1.5f;
            }
            else
            {
                sound.feetPlayer.pitch = 3f;
            }
            sound.PlayWholeSound(sound.feetPlayer, sound.audioList.LightArmourWalking);
        }
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected void FaceTarget()
    {
        if (stateMachine.Targeter.CurrentTarget == null) { return; }

        Vector3 lookPos = stateMachine.Targeter.CurrentTarget.transform.position -
            stateMachine.transform.position;// target.position - our.position
        lookPos.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }

    public void ReturnToLocomotion()// caused a stack overflow winstate and reset statemachine switch state
    {
        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
        /*
        if (stateMachine.Targeter.CurrentTarget != null)
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
        }
        else
        {
            //stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
        */
    }
}
