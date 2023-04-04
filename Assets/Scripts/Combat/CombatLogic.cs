using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLogic : MonoBehaviour
{
    [SerializeField] public UIManager uIManager;
    // Get Stats
    //public float DodgeDuration { get; private set; } dodging
    //public float DodgeProtection { get; private set; } dodging
    //public float BlockProtection { get; private set; } blocking
    //public float DodgeLength { get; private set; } dodging
    //public float JumpForce { get; private set; }// strength or agility

    //[Range(1, 99)]
    //[SerializeField] int startingLevel = 1;

    private bool isInvulnerable = false;//question your choices
    private bool isDodged = false;
    //private bool isEnemy = false;
    public float absorbDamage = 1f;

    public bool GetIsInvulnerable()// this will be SOMETHING
    {
        return isInvulnerable;//block or dodge chance 100%
    }

    public void SetInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;//block or dodge chance 100%
    }

    public void SetAbsorbDamage(float absorbDamage)// this will be armor
    {
        this.absorbDamage = absorbDamage;//block damage soaked
    }

    public bool GetIsDodge()
    {
        return isDodged;
    }

    public void SetIsDodge(bool isDodged)
    {
        this.isDodged = isDodged;
    }

    public void SetDefenceVsHit(float protection)// this is Defence(dodge) did it succeed! 1
    {
        float hitRoll = UnityEngine.Random.Range(0f, 1f);
        if (hitRoll > protection)
        {
            Debug.Log("You dodged failure! hitRoll is" + hitRoll + "and protection is" + protection);
            SetIsDodge(false);
        }
        else
        {
            Debug.Log("You dodged success! hitRoll is" + hitRoll + "and protection is" + protection);
            SetIsDodge(true);
        }
    }

    public void SetDefenceVsDamage(float protection)// How much damage did block absorb!
    {
        float damageMultipler = 1 - protection;
        SetAbsorbDamage(damageMultipler);
    }

    public float GetModifiedDamage(int damage)
    {

        float modifiedDamage = damage * absorbDamage; //= 0;
        PlayCombatSound(modifiedDamage);

        return modifiedDamage;
    }

    private void PlayCombatSound(float modifiedDamage)
    {
        SoundManager soundManager = GetComponentInParent<SoundManager>();

        if (absorbDamage < 1)//hit and block true
        {
            Debug.Log("play block");
            soundManager.PlaySound(soundManager.battlePlayer, soundManager.audioList.sheildBlock);
            Debug.Log("Received reduced damaged of: " + (int)modifiedDamage);
        }
        else if (isDodged)
        {
            Debug.Log("play whoosh");
            soundManager.PlaySound(soundManager.battlePlayer, soundManager.audioList.lightSwing);
            Debug.Log("You dodged success!");
        }
        else
        {
            Debug.Log("play impact");// dodge false/ block false
            soundManager.PlaySound(soundManager.battlePlayer, soundManager.audioList.impacts);
            Debug.Log("Was damaged by full amount: " + (int)modifiedDamage);
            StatManager stat = transform.parent.parent.GetComponent<StatManager>();
            if (stat.GetIsEnemy())
            {
                //uIManager.strength += 1;
                //uIManager.SetStrengthLabel(uIManager.strength);
            }
        }
    }
}
