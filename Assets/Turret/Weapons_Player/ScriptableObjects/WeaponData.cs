using UnityEngine;

[CreateAssetMenu(
   fileName = "WeaponData",
   menuName = "ScriptableObjects/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Stats")]
    public float damage = 25f;
    public float fireRate = 2f;              // irrelevant for secondary since we have cooldown 

    [Header("ProjectileSettings")]
    public float projectileSpeed = 2f;
    public float projectileLifetime = 5f;

       [Header("Visual")]
    public Projectile projectilePrefab;             // use projectiles we made 

    [Header("Weapon Type")]
    public bool isPrimaryWeapon = true;

    public float cooldown = 0f; 
}