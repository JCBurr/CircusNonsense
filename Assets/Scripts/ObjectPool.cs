using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // SharedInstance is a Singleton object to control the various ObjectPools
    public static ObjectPool SharedInstance;

    // Pooled object lists
    public List<GameObject> pooledProjectileObjects;
    public List<GameObject> pooledDuckObjects;

    // References to prefabs to be pooled
    public GameObject projectilePool;
    public GameObject duckPool;

    // Number of objects of each type to pool
    public int projectilesToPool;
    public int ducksToPool;

    void Awake()
    {
        // Create Singleton instance
        SharedInstance = this;
    }

    void Start()
    {
        InstatiateProjectilePool();
        InstatiateDuckPool();
    }

    public GameObject GetPooledProjectile()
    {
        for (int i = 0; i < projectilesToPool; i++)
        {
            if (!pooledProjectileObjects[i].activeInHierarchy)
            {
                return pooledProjectileObjects[i];
            }
        }
        return null;
    }

    public GameObject GetPooledDuck()
    {
        for (int i = 0; i < ducksToPool; i++)
        {
            if (!pooledDuckObjects[i].activeInHierarchy)
            {
                return pooledDuckObjects[i];
            }
        }
        return null;
    }

    private void InstatiateProjectilePool()
    {
        pooledProjectileObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < projectilesToPool; i++)
        {
            tmp = Instantiate(projectilePool);
            tmp.SetActive(false);
            pooledProjectileObjects.Add(tmp);
        }
    }

    private void InstatiateDuckPool()
    {
        pooledDuckObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < ducksToPool; i++)
        {
            tmp = Instantiate(duckPool);
            tmp.SetActive(false);
            pooledDuckObjects.Add(tmp);
        }
    }

}
