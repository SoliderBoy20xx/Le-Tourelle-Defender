using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Waves")]
    [SerializeField]
    private WaveData[] waves;    // waves

    [Header("Spawn Points")]
    [SerializeField]
    private Transform[] spawnPoints;

    [Header("Target")]
    [SerializeField]
    private Transform target;       // base 

    private int currentWaveIndex;  // track current wave

    private void Start()
    {
        StartCoroutine(StartWaveRoutine());
    }

    private IEnumerator StartWaveRoutine()
    {
        while (currentWaveIndex < waves.Length)
        {
            yield return SpawnWave(waves[currentWaveIndex]);
            currentWaveIndex++;
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator SpawnWave(WaveData wave)
    {
        foreach (EnemySpawnInfo enemyInfo in wave.enemies)
        {
            for (int i = 0; i < enemyInfo.amount; i++)
            {
                SpawnEnemy(enemyInfo.enemyPrefab);
                 yield return new WaitForSeconds(wave.spawnDelay);
            }
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        Transform spawnPoint =spawnPoints[Random.Range(0,spawnPoints.Length)];  // rabndom spawn point

        GameObject enemy =PoolManager.Instance.Get(enemyPrefab); // use pool mg to spawn 

        enemy.transform.SetPositionAndRotation(spawnPoint.position,Quaternion.identity);

        enemy.GetComponent<EnemyMovement>().SetTarget(target); 
    }
}