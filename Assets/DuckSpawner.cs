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
        duckSpawnLocationList = new GameObject[3];

        for (int i = 0; i < 3; i++) 
        {
            duckSpawnLocationList[i] = gameObject.transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDucks()
    {
            StartCoroutine(SpawnDuckRoutine());
    }

    IEnumerator SpawnDuckRoutine()
    {
        for (int j = 0; j <= 5; j++)
        {
            for (int i = 0; i < duckSpawnLocationList.Length; i++)
            {
                GameObject duck = ObjectPool.SharedInstance.GetPooledDuck();
                if (duck != null)
                {
                    if (i == 0 || i == 2)
                    {
                        duck.GetComponent<DuckObjectController>().movementTargetDirection = 1;
                    }
                    else
                    {
                        duck.GetComponent<DuckObjectController>().movementTargetDirection = 0;
                    }
                    duck.transform.position = duckSpawnLocationList[i].transform.position;
                    duck.transform.rotation = duckSpawnLocationList[i].transform.rotation;
                    duck.SetActive(true);
                }
                yield return new WaitForSeconds(1);
            }
        }
    }
}
