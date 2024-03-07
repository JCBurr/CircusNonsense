using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class DuckSpawner : MonoBehaviour
{

    public GameObject[] duckSpawnLocationList;

    // Start is called before the first frame update
    void Start()
    {
        // Store all duck spawn locations
        // To add more, create the object in the Editor and increment this
        // array size and loop length by 1.
        duckSpawnLocationList = new GameObject[3];

        for (int i = 0; i < 3; i++) 
        {
            // Get all child GameObjects on this object.
            // All child GameObjects on the DuckSpawns object should be duck spawn locations
            // Duck spawn locations are empty GameObjects
            duckSpawnLocationList[i] = gameObject.transform.GetChild(i).gameObject;
        }

    }

    public void SpawnDucks()
    {
        // Begin the coroutine which handles duck spawning
        // Using a coroutine partly to keep this on a separate thread
        // and partly to ensure we can wait for a certain amount of time
        // between each spawn to stagger them
        StartCoroutine(SpawnDuckRoutine());
    }

    IEnumerator SpawnDuckRoutine()
    {
        // Number of loops = number of ducks to spawn at each location
        for (int j = 0; j <= 5; j++)
        {
            // Iterate through all duck spawn locations.
            for (int i = 0; i < duckSpawnLocationList.Length; i++)
            {
                GameObject duck = ObjectPool.SharedInstance.GetPooledDuck();
                if (duck != null)
                {
                    // Ensure that every other duck spawn location has ducks that
                    // spawn in opposing directions.
                    if (i == 0 || i == 2)
                    {
                        duck.GetComponent<DuckObjectController>().movementTargetDirection = 1;
                    }
                    else
                    {
                        duck.GetComponent<DuckObjectController>().movementTargetDirection = 0;
                    }

                    // Set position and rotation of the duck and enable it
                    duck.transform.position = duckSpawnLocationList[i].transform.position;
                    duck.transform.rotation = duckSpawnLocationList[i].transform.rotation;
                    duck.SetActive(true);
                }
                // Delay to have ducks spawn one after the other
                yield return new WaitForSeconds(1);
            }
        }
    }
}
