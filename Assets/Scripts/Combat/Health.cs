using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Image healthBar;

    private int health;
    private bool isInvulnerable;//question your choices

    public event Action OnTakeDamage;
    public event Action OnDie;

    private void Start()
    {
        health = maxHealth;
    }

    public void SetInvulnerable(bool isInvulnerable)// this will be armor
    {
        this.isInvulnerable = isInvulnerable;
    }

    public void DealDamage(int damage)
    {
        if (health == 0) { return; }

        if (isInvulnerable) { return; }

        health = Mathf.Max(health - damage, 0);

        OnTakeDamage?.Invoke();

        if (health == 0)
        {
            OnDie?.Invoke();
        }

        float lostHealth = damage / 100f;
        healthBar.fillAmount -= lostHealth;
        Debug.Log(health);
    }
}
