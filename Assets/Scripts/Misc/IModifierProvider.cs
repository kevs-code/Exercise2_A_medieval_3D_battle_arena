using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModifierProvider
{
    IEnumerable<float> GetAdditiveModifiers(Stats stat);//int
    IEnumerable<float> GetPercentageModifiers(Stats stat);//int
}
