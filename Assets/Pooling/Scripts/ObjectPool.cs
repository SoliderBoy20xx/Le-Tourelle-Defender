/* 

    create a pool queue to store objects 
    Enqueue to add instead of destroying (set active false)
    Dequeue to get instead of instantiating (set active true)
    Use Ipool interface to call spawn and despawn to reset , don't forget to implement that interface

*/






using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private readonly Queue<GameObject> poolQueue = new Queue<GameObject>();    

    private readonly GameObject prefab;   // hold the prefab ref , 
                                         // private cuz no one outside should change it , readonly cuz we already set it in constr and not gonna change it anyway
    private readonly Transform parent;

    public ObjectPool( GameObject prefab, int initialSize, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;

        for (int i = 0; i < initialSize; i++)
        {
            CreateObject();
        }
    }  // constructor will init x objects in pool and set prefab and parent transform refs 

    private GameObject CreateObject()
    {
        GameObject obj = Object.Instantiate(prefab, parent);
        // new fix 
        PoolableObject poolable = obj.GetComponent<PoolableObject>(); 
        // set pool ref to later know where to return 
    //  Debug.Log($"Set pool for {obj.name}");
        poolable?.SetPool(this);


        obj.SetActive(false);
        poolQueue.Enqueue(obj);
        return obj;
    }  // create object, desactivate , add to queue 

    public GameObject Get()
    {
        if (poolQueue.Count == 0)
        {
            CreateObject();      // create one if empty 
        }

        GameObject obj = poolQueue.Dequeue();
        obj.SetActive(true);
        IPoolable poolable = obj.GetComponent<IPoolable>(); poolable?.OnSpawn();
        return obj;
    }   // get obj from pool , activate it , call onSpawn if implemented (reset health....) 
 
    public void Release(GameObject obj)
    {
        Debug.Log($"Releasing {obj.name}");
        IPoolable poolable = obj.GetComponent<IPoolable>(); poolable?.OnDespawn();
         obj.SetActive(false);
          poolQueue.Enqueue(obj);
            //Debug.Log($"Queue count: {poolQueue.Count}");
    }
}       // when done using obj, call Despawn, desactivate ,enqueue back 


// Create Object called when pool empty 
// Release when done with object (died.....)
//both basically do the same thing but different reasons