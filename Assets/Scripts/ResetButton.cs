using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private Button resetButton;
    //[SerializeField] private PlayerStateMachine player;
    //[SerializeField] private EnemyStateMachine enemy;//GameObject[]
    //[SerializeField] private EnemySpawner enemySpawner;


    private void Start()
    {
        resetButton.onClick.AddListener(() =>
        {
            ResetScene();
        });
    }

    private void ResetScene()
    {
        /*
        // just make an object pool like car parent! Put this back!

        //reset... transforms and health for player and enemy change round number change enemy or enemy health
        Debug.Log(player.gameObject.transform + "\n" + enemy.gameObject.transform);
        player.Controller.enabled = false;
        
        player.transform.position = Vector3.zero;
        player.transform.rotation = new Quaternion(0, 0, 0, 1);
        player.Controller.enabled = true;
        enemy.Controller.enabled = false;
        //enemy.Agent.enabled = false;
        enemy.transform.position = new Vector3(5f, 0f, 16f);
        //enemy.transform.position = enemy.RefTransform.position;
        enemy.transform.Rotate(0, 180, 0);

        //enemy.Agent.enabled = true;
        enemy.Controller.enabled = true;
        //player.Health.SetHealth(player);
        //enemy.Health.SetHealth(enemy);
        new PlayerImpactState(this)
        */
        //player.Health.SetHealth(player.stats.maxHealth);
        //enemy.Health.SetHealth(enemy.stats.maxHealth);
        //player.SwitchState(new PlayerFreeLookState(player));
        //enemy.SwitchState(new EnemyIdleState(enemy));// restore health, reset combat fever

        //player.gameObject.SetActive(false);
        //player.transform.position = Vector3.zero;
        //player.transform.rotation = new Quaternion(0, 0, 0, 1);
        //player.gameObject.SetActive(true);
        //enemySpawner.SetActiveEnemy(0);
        SceneManager.LoadScene(1);
    }
}
/*private readonly Vector3 Offset = new Vector3(0f, 2.325f, 0.65f);
stateMachine.Controller.enabled = false;
stateMachine.transform.Translate(Offset, Space.Self);
stateMachine.Controller.enabled = true;*/