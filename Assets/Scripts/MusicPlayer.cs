using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioList audioList;
    
    private void Start()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        if (!musicPlayer.isPlaying)
        {
            int playIndex = Random.Range(0, audioList.Music.Count);
            musicPlayer.clip = audioList.Music[playIndex];
            musicPlayer.Play();//loop?
        }
        else
        {
            //stateMachine.AudioPlayer.Stop();
        }
    }
}
