using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerStateMachine stateMachine;
    [SerializeField] EnemyStateMachine enemyStateMachine;
    [SerializeField] public CombatLogic combatLogic;
    [SerializeField] TextMeshProUGUI strengthLabel; 
    [SerializeField] TextMeshProUGUI healthEnemyLabel;
    [SerializeField] TextMeshProUGUI timeLabel;
    [SerializeField] TextMeshProUGUI announceLabel;
    [SerializeField] TextMeshProUGUI gameAnnounceLabel;
    public int strength;//or private us statemachine
    public event Action OnWin;
    private int health;
    private int time;
    void Start()
    {
        strength = stateMachine.Strength;
        health = enemyStateMachine.Health.GetHealth();
        time = 12;
        SetStrengthLabel(strength);
        SetHealthLabel(health);
        SetTimeLabel(time);
        SetAnnounceLabel(announceLabel.text);

    }

    public void SetGameAnnounceLabel(string final)
    {
        OnWin?.Invoke();
        StartCoroutine(FinalTextFadeCoroutine(final));
    }

    public void SetAnnounceLabel(string announce)
    {
        StartCoroutine(TextFadeCoroutine(announce));
    }

    public void SetStrengthLabel(int strength)
    {
        this.strength = strength;
        stateMachine.Strength = strength;//issue
        strengthLabel.text = strength.ToString();
    }

    public void SetHealthLabel(int health)
    {
        this.health = health;
        healthEnemyLabel.text = health.ToString();
    }


    public void SetTimeLabel(int time)
    {
        timeLabel.text = time.ToString();
    }

    public void ChangeScene(int index)
    {
        StartCoroutine(LoadCoroutine(index));
        //LoadScene(index);
    }

    public void LoadScene(int index)
    {
        if (index == 0)
        {
            SceneManager.LoadScene(0);//goto menu
        }
        else
        {
            Scene scene = SceneManager.GetActiveScene();
            int count = SceneManager.sceneCountInBuildSettings;
            if (scene.buildIndex + 1 < count)
            {
                SceneManager.LoadScene(scene.buildIndex + 1);
            }
            else if (scene.buildIndex + 1 == count)
            {
                SetAnnounceLabel("Final Victory!");
                //stateMachine.AnnouncerLabel.text = "Final Victory!";
                ChangeScene(0);
            }
            else
            {
                ChangeScene(0);
            }
        }
    }

    IEnumerator TextFadeCoroutine(string announce)
    {
        //yield return StartCoroutine(FadeInText(1f, textToUse));
        announceLabel.text = announce;
        yield return new WaitForSeconds(2f);
        announceLabel.text = "";
        //yield return StartCoroutine(FadeOutText(1f, textToUse));
    }

    IEnumerator FinalTextFadeCoroutine(string final)
    {
        //yield return StartCoroutine(FadeInText(1f, textToUse));
        yield return new WaitForSeconds(5f);
        gameAnnounceLabel.color = Color.yellow;
        gameAnnounceLabel.text = final;
        yield return new WaitForSeconds(5f);
        // announceLabel.text = "";
        //yield return StartCoroutine(FadeOutText(1f, textToUse));
    }

    IEnumerator LoadCoroutine(int index)
    {
        //if index == .count you win final!
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 6 seconds.
        yield return new WaitForSeconds(6);

        //After we have waited 6 seconds print the time again.
        LoadScene(index);
        //InstantiateBullet(index);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void InstantiateBullet(int index)
    {
        enemyStateMachine.gameObject.SetActive(false);

        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = new Vector3(5f, 0f, 16f);
            bullet.transform.Rotate(0, 180, 0);
            bullet.SetActive(true);
        }
    }
}
