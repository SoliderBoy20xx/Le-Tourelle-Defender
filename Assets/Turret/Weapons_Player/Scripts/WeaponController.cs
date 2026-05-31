//read data of scriptable object asset and handle fire rate , cooldown(2nd).....




using UnityEngine;
using UnityEngine.InputSystem;
public class WeaponController : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] private WeaponData primaryWeapon;
    [SerializeField] private WeaponData secondaryWeapon;

    [Header("Spawn")]
    [SerializeField] private Transform spawnPoint; // gonna use same barrel for now diff projectiles 

    // timers fo enough delay betwen bullets 
    private float primaryTimer;
    private float secondaryTimer;

    private void Update()
    {
        HandlePrimaryFire();
        HandleSecondaryFire();
    }







    private void HandlePrimaryFire()
    {
        primaryTimer += Time.deltaTime;
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            if (primaryTimer >= 1f / primaryWeapon.fireRate)
            // shots per second to secs per shot , time between shots
            {
                Fire(primaryWeapon);
                primaryTimer = 0f;
            }
        }
    }

    private void HandleSecondaryFire()
    {
        secondaryTimer += Time.deltaTime;
        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            if (secondaryTimer >= secondaryWeapon.cooldown)
            {
                Fire(secondaryWeapon);
                secondaryTimer = 0f;
            }
        }
    }

    private void Fire(WeaponData weapon)
{
    Projectile projectile =
        Instantiate(weapon.projectilePrefab, spawnPoint.position, spawnPoint.rotation);

    projectile.Initialize(  weapon.damage, weapon.projectileSpeed,weapon.projectileLifetime);
}

    private GameObject InstantiateProjectile()
    {
        // TEMP (we will replace with Pool later)
        return GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }
}