using UnityEngine;

[CreateAssetMenu(
   fileName = "WeaponData",
   menuName = "Data/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Stats")]
    public float damage = 25f;
    public float fireRate = 4f;

    [Header("ProjectileSettings")]
    public float projectileSpeed = 20f;
    public float projectileLifetime = 5f;

    [Header("Weapon Type")]
    public bool isPrimaryWeapon = true;

    public float cooldown = 0f; 
}