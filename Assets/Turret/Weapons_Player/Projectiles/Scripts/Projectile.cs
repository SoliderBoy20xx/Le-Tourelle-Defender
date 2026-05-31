using UnityEngine;

// public class Projectile : MonoBehaviour
 // public class Projectile : MonoBehaviour, IPoolable

public class Projectile : PoolableObject
{
    private float speed;
    private float damage;
    private float lifeTime;
    private float timer;

    public void Initialize(float damage, float speed, float lifeTime)
    {
        this.damage = damage;
        this.speed = speed;
        this.lifeTime = lifeTime;

        timer = 0f;
    }
    // set the values when spawned 

    private void Update()
    {
       Move();
        HandleLifetime();
    }

    private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
     
    }

    private void HandleLifetime()
    {
        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)     // make sure collider trigger
    {
        Enemies enemy = other.GetComponent<Enemies>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        // gameObject.SetActive(false); // TEMP (will become Pool later)

        ReturnToPool(); // call now from poolableObj
    }


public override void OnSpawn()
{
    timer = 0f;
}




}



// this is just projectile mvm, damage passed from weapon
//each weap got damage and speed passed tp projectile 