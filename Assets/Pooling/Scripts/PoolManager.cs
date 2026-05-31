using System.Collections.Generic;
using UnityEngine;



//Created a pool manager and did not use unity pool system cuz it is designed for specific type and i want to pull anything 

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance; // static for other scripts to access , use one for all and no need to pass pool manager ref around
    private Dictionary<GameObject, ObjectPool> pools = new Dictionary<GameObject, ObjectPool>();  // using a dictionary to hold multiple pools diff objs , better than unity pool system 

// init pools
[SerializeField]
private GameObject fastEnemyPrefab;

[SerializeField]
private GameObject tankEnemyPrefab;

[SerializeField]
private GameObject PrimaryprojectilePrefab;
[SerializeField]
private GameObject secondaryProjectilePrefab;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }                                // either set instance or destory if one exists , making sure only ine manager exists 
        else
        {
            Destroy(gameObject);
        }

        // init pools 
    //Debug.Log($"Fast Pool Ref: {fastEnemyPrefab}");
    //Debug.Log($"Tank Pool Ref: {tankEnemyPrefab}");
    CreatePool(fastEnemyPrefab, 20);
    CreatePool(tankEnemyPrefab, 10);
    CreatePool(PrimaryprojectilePrefab, 100);
    CreatePool(secondaryProjectilePrefab, 10);
    }

    public void CreatePool(GameObject prefab,int size)
    {
        if (pools.ContainsKey(prefab))
            return;  // check if already exists                                             

        Debug.Log($"Creating pool: {prefab.name}");
        ObjectPool pool = new ObjectPool( prefab, size, transform);  // create an instance of pool for an object using the ObjectPool calss we made
                

        pools.Add(prefab, pool); // finally add it to dict with prefab as key and pool as value 
    }

    public GameObject Get(GameObject prefab)
    {
        Debug.Log($"Looking for pool: {prefab.name}");
        return pools[prefab].Get();
    } // get obj from pool by prefab key

    public void Release(
        GameObject prefab,
        GameObject obj)
    {
        pools[prefab].Release(obj);
    }// put it back 


}   