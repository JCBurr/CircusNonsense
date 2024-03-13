using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGalleryInit : MonoBehaviour
{
    public event EventHandler OnStartDuckShootingMinigame;

    public GameObject duckSpawner;

    private Collider duckSpawnCollider;

    private void Start()
    {
        duckSpawnCollider = GetComponent<Collider>();

        DuckSpawner finishShootingMinigame = duckSpawner.GetComponent<DuckSpawner>();
        finishShootingMinigame.OnFinishDuckShootingMinigame += FinishDuckShootingMinigame;
    }

    // Would make sense to turn this into a UnityEvent in future for cleaner code
    public void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.tag == "Player")
        {
            // Invoke the start event if the event is not null
            OnStartDuckShootingMinigame?.Invoke(this, EventArgs.Empty);

            duckSpawnCollider.isTrigger = false;
        }
    }

    private void FinishDuckShootingMinigame(object sender, EventArgs e)
    {
        // Re-enable the trigger after the minigame is finished
        duckSpawnCollider.isTrigger = true;
    }

}
