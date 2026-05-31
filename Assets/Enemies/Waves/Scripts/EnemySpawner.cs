using UnityEngine;
using UnityEngine.InputSystem;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject enemyPrefab;
    [SerializeField] 
    private Transform spawnPoint;
    [SerializeField] 
    private Transform target;

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Spawn();
        }
    }

private void Spawn()
{
    GameObject enemy =PoolManager.Instance.Get(enemyPrefab);
    enemy.transform.SetPositionAndRotation(spawnPoint.position,Quaternion.identity);
    enemy.GetComponent<EnemyMovement>().SetTarget(target);
}
}

// temp for testing 
//use table transform for spawn points and target later