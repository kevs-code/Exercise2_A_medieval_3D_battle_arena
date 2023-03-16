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
    [SerializeField] public TextMeshProUGUI gameAnnounceLabel;
    //[SerializeField] public StatManager
    //public int strength;//or private us statemachine
    private int health;

    //private int time;
    public float TimeLeft = 60;
    private bool TimerOn = false;


    public event Action OnWin;
    void Start()
    {

        //strength = stateMachine.Strength;
        health = enemyStateMachine.Health.GetHealth();
        //time = 12;
        //SetStrengthLabel(strength);
        SetHealthLabel(health);
        TimerOn = true;
        SetAnnounceLabel(announceLabel.text);

    }

    private void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Timer is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        int seconds = Mathf.FloorToInt(currentTime % 60);

        SetTimeLabel(seconds);
    }

    public void SetGameAnnounceLabel(string final)//triggers on win
    {
        OnWin?.Invoke();//only player subscribed
        StartCoroutine(FinalTextFadeCoroutine(final));
        //stateMachine.UIManager.gameAnnounceLabel.color = Color.red;//update enemydeadstate
    }

    public void SetAnnounceLabel(string announce)
    {
        StartCoroutine(TextFadeCoroutine(announce));
    }

    public void SetStrengthLabel(int strength)
    {
        // this.strength = strength;
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
        yield return new WaitForSeconds(5f);
        gameAnnounceLabel.color = Color.yellow;
        gameAnnounceLabel.text = final;
        yield return new WaitForSeconds(5f);
        // announceLabel.text = "";
    }

    IEnumerator LoadCoroutine(int index)
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(6);
        LoadScene(index);//replace with reset update stats
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

}
