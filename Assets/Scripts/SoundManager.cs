using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour//static?
{
    [SerializeField] private AudioSource battlePlayer;
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource voicePlayer;
    public AudioSource audioSource;//can you get hold of musicplayer and player[this(battlesounds)] and head(efforts)
    [SerializeField] private AudioList audioList;

    private void Awake()
    {
        audioSource = battlePlayer;
    }
    public void PlaySound(AudioSource source, List<AudioClip> sound)//static?
    {
        int playIndex = Random.Range(0, sound.Count);

        battlePlayer.clip = sound[playIndex];
        battlePlayer.PlayOneShot(battlePlayer.clip);
    }

    /*refactor musicplayer, playerbasestate, Health,
private void BattleData()
{
    List<AudioClip> swordSword = audioList.swordSword;
    List<AudioClip> swordSheild = audioList.swordSheild;
    List<AudioClip> sheildSheild = audioList.sheildSheild;
    List<AudioClip> sheildBash = audioList.sheildBash;
    List<AudioClip> lightSwing = audioList.lightSwing;
    List<AudioClip> heavySwing = audioList.heavySwing;
    List<AudioClip> impacts = audioList.impacts;
}
*/
}
