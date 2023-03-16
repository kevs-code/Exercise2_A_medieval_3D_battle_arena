using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour//static?
{
    [SerializeField] public AudioSource battlePlayer;
    [SerializeField] public AudioSource musicPlayer;
    [SerializeField] public AudioSource voicePlayer;
    [SerializeField] public AudioSource feetPlayer;//actually just on player right now!
    // public AudioSource audioSource;//can you get hold of musicplayer and player[this(battlesounds)] and head(efforts)
    [SerializeField] public AudioList audioList;

    private void Awake()
    {
        // audioSource = battlePlayer;
    }

    private void Start()
    {
        PlayWholeSound(musicPlayer, audioList.Music);
    }

    public void PlaySound(AudioSource source, List<AudioClip> sound)//static?
    {
        int playIndex = Random.Range(0, sound.Count);

        source.clip = sound[playIndex];
        source.PlayOneShot(source.clip);
    }

    public void PlayWholeSound(AudioSource source, List<AudioClip> sound)//static?
    {
        if (!source.isPlaying)//OnPlayerParentAudioSource
        {
            int playIndex = Random.Range(0, sound.Count);

            source.clip = sound[playIndex];
            source.Play();
        }
        /*
        else
        {
            source.Stop();
        }*/
    }
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
