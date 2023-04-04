using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
using System;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private Button resetButton;
    [SerializeField] private PlayerStateMachine player;
    private EnemyStateMachine enemy;
    [SerializeField] public EnemySpawner enemySpawner;
    [SerializeField] public EnemyStateMachine[] enemies;

    public bool isReset = false;
    private void Start()
    {
        resetButton.onClick.AddListener(() =>
        {
            isReset = true;
            ResetScene();
            isReset = false;
        });
    }

    public void ResetScene()
    {
        int index = enemySpawner.GetIndex();// get current index
        enemy = enemies[index];// gives the enemy the right state machine the current one
        if (isReset)
        {
            Debug.Log("Coroutines stopped");
            gameObject.GetComponentInParent<RoundManager>().StopAllCoroutines();//or we still need to settextfalse etc
        }
        
        ResetFighters(index);
    }

    public void ResetFighters(int index)
    {
        if (isReset)
        {
            // We do this in EnemyDeadState otherwise, maybe because we don't call reset fighters at all SceneManager.LoadScene();
            //player.Targeter.Cancel();
            player.Targeter.RemoveTargetWithDelay(enemy.Target);
            //GameObject.Destroy(enemy.Target);
            //enemy.Target.DestroyTarget();
            /*
            player.Targeter.Cancel();
            GameObject.Destroy(enemy.Target);
            */
        }
        StartCoroutine(LoadCoroutine(index));
    }

    private void ResetPlayer()
    {
        // We try to undo deadstate ragdoll physics set in dead states
        player.Ragdoll.ToggleRagdoll(false);
        // will we get a stack overflow still as we have paused in Targeter?
        player.SwitchState(new PlayerTargetingState(player));
        // Reset ForceReceiver
        player.ForceReceiver.Reset();

        // Reset stats and or progression
        player.Health.SetHealth(player.stats.maxHealth);

        //combatFever /stamina
        // TODO reset stats

        // Reset the character transform
        player.Controller.enabled = false;
        player.transform.position = Vector3.zero;
        player.transform.rotation = Quaternion.identity;
        player.Controller.enabled = true;
    }

    private void ResetEnemy()
    {
        enemy.Ragdoll.ToggleRagdoll(false);
        enemy.SwitchState(new EnemyIdleState(enemy));
        // Reset navmeshagent
        enemy.Agent.updatePosition = false;
        enemy.Agent.updateRotation = false;
        enemy.Agent.velocity = Vector3.zero;
        enemy.Agent.Warp(enemy.transform.parent.position);
        enemy.Agent.enabled = false;
        enemy.Agent.enabled = true;
        if (enemy.Agent.isOnNavMesh)
        {
            enemy.Agent.destination = Vector3.negativeInfinity;
            enemy.Agent.ResetPath();
        }
        // Reset ForceReceiver
        enemy.ForceReceiver.Reset();
        // Reset stats and or progression
        enemy.Health.SetHealth(enemy.stats.maxHealth);
        // Reset the enemy transform
        enemy.Controller.enabled = false;
        enemy.transform.position = enemy.transform.parent.position;
        enemy.transform.rotation = enemy.transform.parent.rotation;
        enemy.Controller.enabled = true;
    }

    IEnumerator LoadCoroutine(int index)// we're loading the next scene
    {
        Debug.Log("Feels like no time: Passes");
        yield return new WaitForSeconds(6f);//
        ResetPlayer();
        ResetEnemy();
        Debug.Log("Bonzai!");
        GetEnemy(index);
    }


    private void GetEnemy(int index)
    {
        if (!player.RoundManager.isNextFight)
        {
            Debug.Log("nextRound or Reset");
            enemySpawner.SetActiveEnemy(index);
        }
        else
        {
            Debug.Log("next fight");
            enemySpawner.SetActiveEnemy(index + 1);
        }
    }
}