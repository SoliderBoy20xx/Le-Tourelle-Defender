using UnityEngine;


[System.Serializable]
public class EnemySpawnInfo
{
      public GameObject enemyPrefab;
        public int amount;
}

[CreateAssetMenu(
    fileName = "WaveData",
    menuName = "ScriptableObjects/Wave Data")]
public class WaveData : ScriptableObject
{
    [Header("Enemies")]
    public EnemySpawnInfo[] enemies; // types and amount of enemies for the wave 

    [Header("Timing")]
    public float spawnDelay = 1f;
}