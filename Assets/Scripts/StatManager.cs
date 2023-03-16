using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    private bool isEnemy = false;
    public EnemyStateMachine enemyStateMachine;
    public PlayerStateMachine playerStateMachine;
    [SerializeField] public bool shouldUseModifiers = false;
    public int strength;
    public int blocking;
    public int dodging;
    public int combatFever;
    public int stamina;
    public int maxHealth;
    [System.NonSerialized] public float DodgeProtection;
    [System.NonSerialized] public float BlockProtection;
    //[System.NonSerialized]
    private float dodgeProtection;


    private void Awake()
    {
        //experience = GetComponent<Experience>();
        //currentLevel = new LazyValue<int>(CalculateLevel);
    }

    private void Start()
    {
        if (gameObject.TryGetComponent<EnemyStateMachine>(out EnemyStateMachine StateMachine))
        {
            SetIsEnemy(true);
        }
        else
        {
            SetIsEnemy(false);
        }
        //currentLevel.ForceInit();
        GetStatsList(gameObject);
    }

    private void OnEnable()
    {
        //GetStatsList(gameObject);
    }

    private void OnDisable()
    {
    }

    public int GetStrength()
    {
        return strength;//15
    }

    public float GetBlockProtection()
    {
        return 0.5f;
    }

    public float GetDodgeProtection()
    {
        return 0.5f;
    }
    public bool GetIsEnemy()
    {
        return isEnemy;
    }
    public void SetIsEnemy(bool isEnemy)
    {
        this.isEnemy = isEnemy;
    }

    public void GetStatsList(GameObject child)
    {
        if (isEnemy)
        {
            EnemyStateMachine enemy = child.GetComponent<EnemyStateMachine>();//does it need to be there!!!
            this.strength = enemy.stats.strength;
            this.blocking = enemy.stats.blocking;
            this.dodging = enemy.stats.dodging;
            this.combatFever = enemy.stats.combatFever;
            this.stamina = enemy.stats.stamina;
            this.maxHealth = enemy.stats.maxHealth;
            enemy.Health.SetHealth(maxHealth);
        }
        else
        {
            PlayerStateMachine player = child.GetComponent<PlayerStateMachine>();
            this.strength = player.stats.strength;
            this.blocking = player.stats.blocking;
            this.dodging = player.stats.dodging;
            this.combatFever = player.stats.combatFever;
            this.stamina = player.stats.stamina;
            this.maxHealth = player.stats.maxHealth;
            player.Health.SetHealth(maxHealth);
        }
    }


    /*
    // consideration
    weapon damage
        public void SetAttack(int damage, float knockback, int strength)
    {
        //this.damage = damage;
        this.knockback = knockback;
        this.strength = strength;
        Debug.Log(damage + " * 1 + (" + strength + " / 100)");
        this.damage = damage * 1 + (strength / 100);
        Debug.Log("new damage " + this.damage);
    }

    public float GetStat(Stats stat)
    {
        return GetBaseStat(stat) * (1 + GetPercentageModifiers(stat) / 100) + GetAdditiveModifiers(stat);
        // return GetBaseStat(stat) + GetAdditiveModifier(stat) * (1 + GetPercentageModifier(stat)/100);  // bug solved BaseStat.GetStat() was doing this math additive * percentage not base * percentage + additive
    }


    private float GetBaseStat(Stats stat)//stat could just be int
    {
        return 10f;
    }

    private float GetAdditiveModifiers(Stats stat)
    {
        if (!shouldUseModifiers) return 0;

        float total = 0;
        foreach (IModifierProvider provider in GetComponents<IModifierProvider>())
        {
            foreach (float modifier in provider.GetAdditiveModifiers(stat))
            {
                total += modifier;
            }
        }
        return total;
    }

    private float GetPercentageModifiers(Stats stat)
    {
        if (!shouldUseModifiers) return 0;

        float total = 0;
        foreach (IModifierProvider provider in GetComponents<IModifierProvider>())
        {
            foreach (float modifier in provider.GetPercentageModifiers(stat))
            {
                total += modifier;
            }
        }
        return total;
    }
    */
}
