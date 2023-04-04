using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerStateMachine stateMachine;
    [SerializeField] EnemyStateMachine enemyStateMachine;
    [SerializeField] public CombatLogic combatLogic;
    [SerializeField] TextMeshProUGUI healthEnemyLabel;
    [SerializeField] TextMeshProUGUI timeLabel;
    [SerializeField] TextMeshProUGUI announceLabel;
    [SerializeField] public TextMeshProUGUI gameAnnounceLabel;


    private int health;

    public float TimeLeft = 60;
    private bool TimerOn = false;

    void Start()
    {
        health = enemyStateMachine.Health.GetHealth();
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


    public void SetHealthLabel(int health)
    {
        this.health = health;
        healthEnemyLabel.text = health.ToString();
    }

    public void SetTimeLabel(int time)
    {
        timeLabel.text = time.ToString();
    }

    public void SetGameAnnounceLabel(string final)
    {
        StartCoroutine(FinalGameText(final));
    }

    public void SetAnnounceLabel(string announce)
    {
        StartCoroutine(AnnounceText(announce));
    }

    IEnumerator AnnounceText(string announce)
    {
        announceLabel.gameObject.SetActive(true);
        announceLabel.text = announce;
        yield return new WaitForSeconds(3f);
        announceLabel.gameObject.SetActive(false);
    }

    IEnumerator FinalGameText(string finalAnnounce)
    {
        gameAnnounceLabel.gameObject.SetActive(true);
        gameAnnounceLabel.color = Color.yellow;
        gameAnnounceLabel.text = finalAnnounce;
        yield return new WaitForSeconds(3f);
        announceLabel.gameObject.SetActive(false);
    }
}
