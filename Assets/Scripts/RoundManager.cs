using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ResetButton resetButton;

    public bool isNextFight = false;
    private int currentRound = 1;
    private int fightsWonInRound = 0;
    private const int fightsToWinRound = 2;
    // private const float roundDelay = 2f;
    
    public event Action OnWin;
    public event Action OnCheer;

    private void Awake()
    {
        uiManager.SetAnnounceLabel("Round " + currentRound + " Fight!");
    }

    public void EnemyWonFight()
    {
        uiManager.SetGameAnnounceLabel("GAME OVER");
        uiManager.SetAnnounceLabel("You Failed!");
        SceneManager.LoadScene(0);
    }

    public void PlayerWonFight()
    { 
        fightsWonInRound++;

        if (fightsWonInRound >= fightsToWinRound)
        {
            HandleFightWinState();//this should be next fight!
        }
        else
        {
            HandleRoundWinState();//this should be next round!
        }
    }

    private void HandleRoundWinState()
    {
        // Show win text
        uiManager.SetAnnounceLabel("You Win the Round!");

        // Increment round number and update round text
        currentRound++;

        // Reset player and enemy transform and stats and sets same active enemy
        resetButton.ResetScene();//think LoadCorountine
        UpdateRoundText();
    }

    private void HandleFightWinState()
    {
        int index = enemySpawner.GetNextIndex();
        Debug.Log("Index: " + index);
        if (index == 0)
        {
            // returns to menu after winning game
            uiManager.SetAnnounceLabel("Final Victory!");
            uiManager.SetGameAnnounceLabel("YOU WON THE GAME!");
            // invoke on win the final fight long celebration animation 10 secs
            OnWin?.Invoke();
 
            // or pause for loadcoroutine
            StartCoroutine(LoadCoroutine());
        }
        else
        {
            uiManager.SetAnnounceLabel("You Win!");
            // invoke fight win cheer we need to add this!
            OnCheer?.Invoke();//we cheer then immediately move to idle in resetscene
            // Reset player and enemy transform and stats here
            isNextFight = true;
            resetButton.ResetScene();
            isNextFight = false;
            // Update round text
            UpdateRoundText();
            Debug.Log("fightsWonInRound");
            fightsWonInRound = 0;// does this make sense now!
        }
    }

    IEnumerator LoadCoroutine()// we're loading the next scene
    {
        yield return new WaitForSeconds(6f);// do we need to delete target 1st and play animation! we already do when enemy dies

        SceneManager.LoadScene(0);
    }

private void UpdateRoundText()
    {
        uiManager.SetAnnounceLabel("Round " + currentRound + " Fight!");
        uiManager.TimeLeft = 60;
    }
}