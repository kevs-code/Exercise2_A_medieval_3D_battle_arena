using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerStateMachine stateMachine;
    [SerializeField] EnemyStateMachine enemyStateMachine;
    [SerializeField] TextMeshProUGUI StrengthLabel; 
    [SerializeField] TextMeshProUGUI HealthEnemyLabel;
    [SerializeField] TextMeshProUGUI TimeLabel;
    [SerializeField] TextMeshProUGUI AnnounceLabel;
    private int strength;
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
        SetAnnounceLabel("Round 2 Fight!");
    }

    public void SetAnnounceLabel(string announce)
    {
        AnnounceLabel.text = announce;
    }

    public void SetStrengthLabel(int strength)
    {
        this.strength = strength;
        StrengthLabel.text = strength.ToString();
    }

    public void SetHealthLabel(int health)
    {
        this.health = health;
        HealthEnemyLabel.text = health.ToString();
    }


    public void SetTimeLabel(int time)
    {
        TimeLabel.text = time.ToString();
    }
}
