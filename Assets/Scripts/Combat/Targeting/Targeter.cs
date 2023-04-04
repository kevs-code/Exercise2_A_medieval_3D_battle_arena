using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup cineTargetGroup;
    private Camera mainCamera;

    private List<Target> targets = new List<Target>();
    public Target CurrentTarget { get; set; }

    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Target>(out Target target)) { return; }
        targets.Add(target);
        target.OnDestroyed += RemoveTarget;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Target>(out Target target)) { return; }
        RemoveTargetWithDelay(target);
    }

    public bool SelectTarget()
    {
        if (targets.Count == 0) { return false; }

        Target closestTarget = null;
        float closestTargetDistance = Mathf.Infinity;

        foreach (Target target in targets)
        {
            Vector2 viewPos = mainCamera.WorldToViewportPoint(target.transform.position);
            // only captures targets in view
            // viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1

            if (!target.GetComponentInChildren<Renderer>().isVisible)
            {
                continue;
            }

            Vector2 toCenter = viewPos - new Vector2(0.5f, 0.5f);
            if (toCenter.sqrMagnitude < closestTargetDistance)
            {
                closestTarget = target;
                closestTargetDistance = toCenter.sqrMagnitude;
            }
        }

        if (closestTarget == null) { return false; }
        CurrentTarget = closestTarget;
        cineTargetGroup.AddMember(CurrentTarget.transform, 1f, 2f);
        return true;
    }

    public void Cancel()
    {
        if (CurrentTarget == null) { return; }// this may very well be null as no longer visible currentTarget

        cineTargetGroup.RemoveMember(CurrentTarget.transform);
        CurrentTarget = null;
    }

    public void RemoveTargetWithDelay(Target target)
    {
        StartCoroutine(Delay(target));
    }

    private IEnumerator Delay(Target target)
    {
        /*
        Collider targetCollider = target.GetComponent<Collider>();
        Renderer targetRenderer = target.GetComponent<Renderer>();

        if (targetCollider) targetCollider.enabled = false;
        if (targetRenderer) targetRenderer.enabled = false;
        */
        yield return new WaitForSeconds(1f);
        RemoveTarget(target);
    }

    public void RemoveTarget(Target target)
    {
        /*
        PlayerStateMachine stateMachine = transform.GetComponent<PlayerStateMachine>();//Targeter on player only
        EnemyStateMachine enemyStateMachine = target.gameObject.GetComponent<EnemyStateMachine>();//Target is on the enemy only
        // Remove the target from the target group
        //Cancel();
        // this is the offending behaviour!
        if (target.GetComponent<PlayerStateMachine>() != null)
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
        }
        else if (target.GetComponent<EnemyStateMachine>() != null)
        {
            enemyStateMachine.SwitchState(new EnemyIdleState(enemyStateMachine));
        }
        */
        // all this does is switch state an not even removeTarget
        if (CurrentTarget == target)// will return false after destroy?
        {
            cineTargetGroup.RemoveMember(CurrentTarget.transform);
            CurrentTarget = null;
        }

        target.OnDestroyed -= RemoveTarget;
        targets.Remove(target);
    }
}