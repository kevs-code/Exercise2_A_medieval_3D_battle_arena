using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
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
                stateMachine.AudioPlayerFeet.pitch = 1.5f;
            }
            else
            {
                stateMachine.AudioPlayerFeet.pitch = 3f;
            }
                PlayFootSteps();
        }
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    private void PlayFootSteps()
    {
        if (!stateMachine.AudioPlayerFeet.isPlaying)//OnPlayerParentAudioSource
        {

            int playIndex = UnityEngine.Random.Range(0, stateMachine.PlayList.LightArmourWalking.Count);
            stateMachine.AudioPlayerFeet.clip = stateMachine.PlayList.LightArmourWalking[playIndex];
            stateMachine.AudioPlayerFeet.Play();
        }
        else
        {
            //stateMachine.AudioPlayer.Stop();
        }
        // Debug.Log("Moving " + stateMachine.PlayList.LightArmourWalking.Count + "Also " + stateMachine.AudioPlayer);
    }

    protected void FaceTarget()
    {
        if (stateMachine.Targeter.CurrentTarget == null) { return; }

        Vector3 lookPos = stateMachine.Targeter.CurrentTarget.transform.position -
            stateMachine.transform.position;// target.position - our.position
        lookPos.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }

    protected void ReturnToLocomotion()
    {
        if (stateMachine.Targeter.CurrentTarget != null)
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
        }
        else
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
    }
}
