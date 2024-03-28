using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingMinigameUIController : MonoBehaviour
{

    // NEXT STEP - add full score tracking. Track total ducks to be spawned and 
    // update whenever a duck is hit.
    // Add a "final score" screen when the minigame ends to indicate final score
    // Need to freeze player controls on this screen and add a "Continue" button, or similar

    // The parent GameObject for the duck UI - disabled by default
    public GameObject duckScoreUIParent;

    public GameObject duckSpawner;
    public GameObject shootingGalleryStartButton;

    public TextMeshProUGUI duckScoreText;
    public int duckScore;

    private void Start()
    {
        // Setup the subscriber to the minigame start event
        StartShootingMinigameButton startShootingMinigame = shootingGalleryStartButton.GetComponent<StartShootingMinigameButton>();
        startShootingMinigame.OnStartDuckShootingMinigame += StartDuckShootingMinigame;

        // Subscribe to the "finish duck shooting minigame" event
        DuckSpawner finishShootingMinigame = duckSpawner.GetComponent<DuckSpawner>();
        finishShootingMinigame.OnFinishDuckShootingMinigame += FinishDuckShootingMinigame;
        
    }

    private void StartDuckShootingMinigame(object sender, EventArgs e)
    {
        // Enable the score UI when the minigame start event executes
        duckScoreUIParent.SetActive(true);
    }

    private void FinishDuckShootingMinigame(object sender, EventArgs e)
    {
        // Super hacky way of resetting the score when the minigame ends
        UpdateDuckScore(-duckScore);
        // Disable the UI when the minigame finish event executes
        duckScoreUIParent.SetActive(false);
    }

    public void UpdateDuckScore(int scoreToAdd)
    {
        Debug.Log("Update duck score function run");
        duckScore += scoreToAdd;
        duckScoreText.text = "Score: " + duckScore;
    }

    
}
