using UnityEngine;

public abstract class Enemies : PoolableObject 
{
    [SerializeField]
    protected EnemyData enemyData;  // ref to Scriptable Object 
    private Renderer rend;
    protected float currentHP;     // each enemy gets its own HP based on max from Scr obj 
    public Color Color { get; private set; }  
    public EnemyData EnemyData => enemyData; 


    // implemnting the Pool methods 
    public override void OnSpawn()        
    {
        currentHP = enemyData != null ? enemyData.maxHP : 0f;  // set current HP to max from Scr obj when spawned 
    
    }

    public override void  OnDespawn()       
    {
        // fill later
    }

    public virtual void TakeDamage(float damage)  // override for diffent damage 
    {
        currentHP -= damage;              
        if (currentHP <= 0)
        {
            Die();                            
        }
    }

    protected virtual void Die()
    {
         Debug.Log("Enemy dying");
          Debug.Log( $"Enemy dying. Pool = {owningPool}");
           ReturnToPool();
    }

    protected virtual void Awake()             // caching material once here 
    {
        rend = GetComponent<Renderer>();

        if (enemyData != null)
        {
            if (rend != null && enemyData.material != null)
            {
                rend.material = enemyData.material;  
            }
            

        }
    }

    // base reached logic 
    private void OnTriggerEnter(Collider other)
    {
       
            BaseHealth baseHealth = other.GetComponent<BaseHealth>();

             if (baseHealth != null)
            {
                baseHealth.TakeDamage(enemyData.damageToBase);  
                Die();  
            }
        
    }
}

