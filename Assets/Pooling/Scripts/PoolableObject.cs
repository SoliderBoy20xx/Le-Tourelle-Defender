using UnityEngine;

public abstract class PoolableObject : MonoBehaviour,IPoolable
{
    protected ObjectPool owningPool; // store original ref to fix not knowing which pool is og when returning on despawn

    public void SetPool(ObjectPool pool)
    {
        owningPool = pool;
    }

    public virtual void ReturnToPool()
    {
        owningPool?.Release(gameObject);
    }

    public virtual void OnSpawn() // override in childs 
    {
    }

    public virtual void OnDespawn()
    {
    }
}