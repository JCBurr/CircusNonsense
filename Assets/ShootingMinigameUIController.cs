using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMinigameUIController : MonoBehaviour
{

    // The parent GameObject for the duck UI - disabled by default
    public GameObject duckScoreUIParent;

    public GameObject duckSpawner;
    public GameObject shootingGalleryInit;

    private void Start()
    {
        // Subscribe to the "Start duck shooting minigame" event
        ShootingGalleryInit startShootingMinigame = shootingGalleryInit.GetComponent<ShootingGalleryInit>();
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
        // Disable the UI when the minigame finish event executes
        duckScoreUIParent.SetActive(false);
    }

    
}
