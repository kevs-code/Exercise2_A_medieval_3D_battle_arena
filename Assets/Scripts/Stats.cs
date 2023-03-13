using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "New Stats", order = 0)]
public class Stats : ScriptableObject
{
    public int strength = 10;// We do damage (and hit)
    public int blocking = 10;// We have a better block chance
    public int dodging = 10;// We have a better dodge chance and dodge length... remember
    public int combatFever = 10;// Chance of enemy power attack or better player power attack modifier
    public int Stamina = 10;// Weaker and or slower movement, attack speed
    //public int Resolve;
}
