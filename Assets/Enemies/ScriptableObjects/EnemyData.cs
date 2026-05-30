using UnityEngine;


[CreateAssetMenu (
    fileName = "EnemyData",
    menuName = "ScriptableObjects/EnemyData",
    order = 2
)]

public class EnemyData : ScriptableObject
{
    [Header("Stats")]
    public float maxHP = 100f;
    public float moveSpeed = 4f;

   [Header("Gameplay")]

    public float damageToBase = 10f;


    [Header("Visuals")]

    public Color color = Color.red;


    
}