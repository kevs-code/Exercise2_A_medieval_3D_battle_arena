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
    private bool isInvulnerable = false;//question your choices
    private bool isDodged = false;
    private bool isEnemy = false;
    private float absorbDamage = 1f;

    [field: SerializeField] public AudioSource BattleSounds { get; private set; }
    [field: SerializeField] public AudioList PlayList { get; private set; }
    //private PlayerStateMachine playerStateMachine;
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
    public int GetHealth()// this will be SOMETHING
    {
        return health;
    }

    public void SetHealth()// this will be SOMETHING
    {
        health = maxHealth;
        uiManager.SetHealthLabel(health);
        healthBar.fillAmount = 1;
    }
    public void SetIsEnemy(bool isEnemy)
    {
        this.isEnemy = isEnemy;//Set Climb nextw
    }

    public void SetInvulnerable(bool isInvulnerable)// this will be SOMETHING
    {
        this.isInvulnerable = isInvulnerable;//block or dodge chance 100%
    }

    public void SetAbsorbDamage(float absorbDamage)// this will be armor
    {
        this.absorbDamage = absorbDamage;//block or dodge damage soaked
    }

    public void SetDodge(bool isDodged)
    {
        this.isDodged = isDodged;
    }

    public void SetDefenceVsHit(float protection)// this is Defence(dodge) did it succeed! 1
    {
        float hitRoll = UnityEngine.Random.Range(0f, 1f);
        if (hitRoll > protection)
        {
            Debug.Log("You dodged failure! hitRoll is" + hitRoll + "and protection is" + protection);
            SetDodge(false);
        }
        else
        {
            Debug.Log("You dodged success! hitRoll is" + hitRoll + "and protection is" + protection);
            SetDodge(true);
        }
    }

    public void SetDefenceVsDamage(float protection)// How much damage did block absorb!
    {
        float damageMultipler = 1 - protection;
        SetAbsorbDamage(damageMultipler);
        //when not blocking called Exit .SetDefenceVsDamage 1 - 0 = 1;
    }

    public void PlaySound(List<AudioClip> sound)
    {
        int playIndex = UnityEngine.Random.Range(0, sound.Count);

        BattleSounds.clip = sound[playIndex];
        BattleSounds.PlayOneShot(BattleSounds.clip);
    }

        public void DealDamage(int damage)//DealDamage passthrough in order
    {
        if (health == 0) { return; }

        // refactor
        
        if (isInvulnerable) { return; }

        float modifiedDamage = damage * absorbDamage; //= 0;

        
        if (absorbDamage < 1)//hit and block true
        {
            Debug.Log("play block");
            PlaySound(PlayList.sheildBlock);
            Debug.Log("Received reduced damaged of: " + (int)modifiedDamage);
        }
        else if (isDodged)
        {
            Debug.Log("play whoosh");
            PlaySound(PlayList.lightSwing);
            Debug.Log("You dodged success!");
            return;
        }
        else
        {
            Debug.Log("play impact");// dodge false/ block false
            PlaySound(PlayList.impacts);
            Debug.Log("Was damaged by full amount: " + (int)modifiedDamage);
            if (isEnemy)
            {
                uiManager.strength += 1;
                uiManager.SetStrengthLabel(uiManager.strength);
            }
        }

        health = Mathf.Max(health - (int)modifiedDamage, 0);
        if (isEnemy)
        {
            uiManager.SetHealthLabel(health);
        }
        OnTakeDamage?.Invoke();

        if (health == 0)
        {
            OnDie?.Invoke();
        }

        float lostHealth = modifiedDamage / 100f;
        healthBar.fillAmount -= lostHealth;
        Debug.Log(health);
    }
}
