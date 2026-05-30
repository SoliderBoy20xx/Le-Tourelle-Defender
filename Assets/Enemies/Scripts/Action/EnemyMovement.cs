using UnityEngine;

[RequireComponent(typeof(Enemies))]
public class EnemyMovement : MonoBehaviour
{
    private Enemies enemy;          //ref base 
    private Transform target;

    private void Awake()
    {
        enemy = GetComponent<Enemies>();
    }

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    private void Update()
    {
        if (target == null)
            return;

        transform.position += (target.position - transform.position).normalized
         * enemy.EnemyData.moveSpeed 
         * Time.deltaTime;
    }
}