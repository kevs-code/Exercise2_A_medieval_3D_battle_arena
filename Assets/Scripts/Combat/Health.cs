using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Image healthBar;
    [SerializeField] private UIManager uiManager;

    private int health = 100;
    private bool isEnemy = false;
    private EnemyStateMachine stateMachine;
    public event Action OnTakeDamage;
    public event Action OnDie;

    public bool IsDead => health == 0;


    private void Awake()// spotted race condition on health
    {
        health = maxHealth;
    }

    private void Start()
    {
        if (gameObject.TryGetComponent<EnemyStateMachine>(out EnemyStateMachine stateMachine))
        {
            SetIsEnemy(true);
        }
        else
        {
            SetIsEnemy(false);
        }
    }
    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int maxHealth)
    {
        this.health = maxHealth;
        this.maxHealth = maxHealth;
        uiManager.SetHealthLabel(health);
        healthBar.fillAmount = 1;
    }

    public bool GetIsEnemy()
    {
        return isEnemy;
    }

    public void SetIsEnemy(bool isEnemy)
    {
        this.isEnemy = isEnemy;
    }

    public void DealDamage(int damage)
    {
        if (health == 0) { return; }
        
        if (uiManager.combatLogic.GetIsInvulnerable()) { return; }

        float modifiedDamage = uiManager.combatLogic.GetModifiedDamage(damage);

        health = Mathf.Max(health - (int)modifiedDamage, 0);

        if (isEnemy)
        {
            uiManager.SetHealthLabel(health);//is enemy exists for health label
        }

        OnTakeDamage?.Invoke();

        if (health == 0)
        {
            OnDie?.Invoke();
        }

        float lostHealth = modifiedDamage / maxHealth;//100f
        healthBar.fillAmount -= lostHealth;
    }
}
