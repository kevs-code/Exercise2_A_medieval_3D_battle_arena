using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioList", menuName = "New AudioList", order = 0)]
public class AudioList : ScriptableObject
{
    public List<AudioClip> swordSword;// = new List<AudioClip>();
    public List<AudioClip> swordSheild;
    [SerializeField] public List<AudioClip> sheildSheild;
    [SerializeField] public List<AudioClip> sheildBash;
    [SerializeField] public List<AudioClip> sheildBlock;
    [SerializeField] public List<AudioClip> lightSwing;
    [SerializeField] public List<AudioClip> heavySwing;
    [SerializeField] public List<AudioClip> impacts;
    [field: SerializeField] public List<AudioClip> LightArmourWalking { get; private set; }//18mb so what until you don't need it!
    [SerializeField] public List<AudioClip> lightArmourRunning;
    [SerializeField] public List<AudioClip> Music;
    [SerializeField] public List<AudioClip> grunts;
    [SerializeField] public List<AudioClip> deathSweeps;
    /*
        [SerializeField] public List<AudioClip> announcerEnemyLowHealth;
        [SerializeField] public List<AudioClip> announcerLowHealth;
        [SerializeField] public List<AudioClip> announcerDeathPlayer;
        [SerializeField] public List<AudioClip> announcerDeathEnemy;
        [SerializeField] public List<AudioClip> heavyArmourRunning;
        [SerializeField] public List<AudioClip> heavyArmourWalking;
        [SerializeField] public List<AudioClip> deathImpacts;
    */
}
