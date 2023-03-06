using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSounds : MonoBehaviour
{
    [SerializeField] private AudioSource battleSoundPlayer;
    [SerializeField] private AudioList audioList;
    public void PlaySound(List<AudioClip> sound)
    {
        int playIndex = Random.Range(0, sound.Count);

        battleSoundPlayer.clip = sound[playIndex];
        battleSoundPlayer.PlayOneShot(battleSoundPlayer.clip);
        /*
        if (!battleSoundPlayer.isPlaying)
        {
            // refactor this code in playerBaseState which take footsteps

            int playIndex = Random.Range(0, sound.Count);
            
            battleSoundPlayer.clip = sound[playIndex];
            battleSoundPlayer.PlayOneShot(battleSoundPlayer.clip);//loop?

        }
        else
        {
            //stateMachine.AudioPlayer.Stop();
        }
        */
    }

    /*
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
