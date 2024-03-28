using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShootingMinigameButton : Interactable
{

    public event EventHandler OnStartDuckShootingMinigame;

    private Collider startMinigameButtonCollider;

    public GameObject duckSpawner;

    public void Start()
    {
        startMinigameButtonCollider = GetComponent<Collider>();

        DuckSpawner finishShootingMinigame = duckSpawner.GetComponent<DuckSpawner>();
        finishShootingMinigame.OnFinishDuckShootingMinigame += FinishDuckShootingMinigame;
    }

    public void Interact()
    {
        // Start the shooting minigame
        OnStartDuckShootingMinigame?.Invoke(this, EventArgs.Empty);

        // Disable the collider so the minigame can't be restarted
        // while it's already running
        startMinigameButtonCollider.enabled = false;
    }

    private void FinishDuckShootingMinigame(object sender, EventArgs e)
    {
        // Re-enable the collider so the minigame can be interacted with again
        startMinigameButtonCollider.enabled = true;
    }
}
