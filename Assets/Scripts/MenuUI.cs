using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioList audioList;

    private void Start()
    {
        Button[] buttons = gameObject.GetComponentsInChildren<Button>();
        SceneLoader(buttons);
    }

    private void SceneLoader(Button[] buttons)
    {
        foreach (Button button in buttons)
        {
            if (button.gameObject.name == "Start")
            {
                button.onClick.AddListener(() =>
                {
                    ChangeScene();
                });
            }
            else if (button.gameObject.name == "Quit")
            {
                button.onClick.AddListener(() =>
                {
                    QuitScene();
                });
            }
        }
    }

    public void ChangeScene()
    {
        StartCoroutine(LoadCoroutine());
    }

    public void QuitScene()
    {
        StartCoroutine(QuitCoroutine());
    }

    public void SoundOnOff(AudioSource audioSource)
    {
        PlaySound(audioSource, audioList.deathSweeps);
    }

    public void PlaySound(AudioSource source, List<AudioClip> sound)//static?
    {
        int playIndex = Random.Range(0, sound.Count);

        audioSource.clip = sound[playIndex];
        audioSource.PlayOneShot(audioSource.clip);
    }

    IEnumerator LoadCoroutine()
    {
        SoundOnOff(audioSource);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(1);
    }

    IEnumerator QuitCoroutine()
    {
        SoundOnOff(audioSource);
        yield return new WaitForSeconds(6f);
        Application.Quit();
    }
}
