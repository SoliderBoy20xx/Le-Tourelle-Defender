using UnityEngine;

public class Enemies : MonoBehaviour, IPoolable  // using pool interface  
{
    [SerializeField]
    protected EnemyData enemyData;  // ref to Scriptable Object 
    private Renderer rend;
    protected float currentHP;     // each enemy gets its own HP based on max from Scr obj 
    public Color Color { get; private set; }  
    public EnemyData EnemyData => enemyData; 


    // implemnting the Pool methods 
    public virtual void OnSpawn()           // virtual just in case i need to override later in an enemy type
    {
        currentHP = enemyData != null ? enemyData.maxHP : 0f;  // set current HP to max from Scr obj when spawned 
    
    }

    public virtual void OnDespawn()         // virtual just in case i need to override later in an enemy type
    {
        // adjust later
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
        gameObject.SetActive(false);           // use pool manager later 
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
}

