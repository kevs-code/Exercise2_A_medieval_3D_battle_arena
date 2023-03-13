using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{

    [SerializeField] bool shouldUseModifiers = false;
    // public event Action onLevelUp;

    // LazyValue<int> currentLevel;

    // Experience experience;

    private void Awake()
    {
        //experience = GetComponent<Experience>();
        //currentLevel = new LazyValue<int>(CalculateLevel);
    }

    private void Start()
    {
        //currentLevel.ForceInit();
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    public float GetStat(Stats stat)
    {
        return GetBaseStat(stat) * (1 + GetPercentageModifiers(stat) / 100) + GetAdditiveModifiers(stat);
        // return GetBaseStat(stat) + GetAdditiveModifier(stat) * (1 + GetPercentageModifier(stat)/100);  // bug solved BaseStat.GetStat() was doing this math additive * percentage not base * percentage + additive
    }


    private float GetBaseStat(Stats stat)
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
}
