// pip cam script borrowed from another project 

using UnityEngine;

public class AngledFollowCam : MonoBehaviour
{
    public Transform target;

    [Tooltip("Tag ")]
    public string enemyTag = "enemy";
   
    public bool autoTarget = true;

    [Header("Position")]
    public Vector3 offset = new Vector3(0f, 0f, 1f);
    public float smoothSpeed = 5f;

    [Header("Orbit")]
    public float orbitSpeed = 10f; // degrees per second

    [Header("Bobbing")]
    public float bobAmount = 0.2f;
    public float bobSpeed = 1f;

    private float currentAngle;

    void OnEnable()
    {
        if (autoTarget && (target == null || !target.gameObject.activeInHierarchy))
            AcquireTarget();
    }

    void AcquireTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        for (int i = 0; i < enemies.Length; i++)
        {
         if (enemies[i] != null && enemies[i].activeInHierarchy)
            {
                target = enemies[i].transform;
                return;
            }
        }

        target = null;
    }

    void LateUpdate()
    {
        if (autoTarget && (target == null || !target.gameObject.activeInHierarchy))
        {
            AcquireTarget();
        }

        if (!target) return;

        // Rotate around y of target 
        currentAngle += orbitSpeed * Time.deltaTime;
        Quaternion orbitRotation = Quaternion.Euler(0f, currentAngle, 0f);

        // Apply rotation to offset
        Vector3 rotatedOffset = orbitRotation * offset;

        // Add subtle vertical bobbing
        float bob = Mathf.Sin(Time.time * bobSpeed) * bobAmount;
        rotatedOffset.y += bob;

        Vector3 desiredPosition = target.position + rotatedOffset;

        // Smooth follow
        transform.position = Vector3.Lerp( transform.position, desiredPosition, smoothSpeed * Time.deltaTime );

        // Always look at target
        transform.LookAt(target);
    }
}