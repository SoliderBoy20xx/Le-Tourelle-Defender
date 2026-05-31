using UnityEngine;

public class AngledFollowCam : MonoBehaviour
{
    public Transform target;

    [Header("Position")]
    public Vector3 offset = new Vector3(0f, -2f, -6f);
    public float smoothSpeed = 5f;

    [Header("Orbit")]
    public float orbitSpeed = 10f; // degrees per second

    [Header("Bobbing")]
    public float bobAmount = 0.2f;
    public float bobSpeed = 1f;

    private float currentAngle;

    void LateUpdate()
    {
        if (!target) return;

        // Rotate around target (Y axis)
        currentAngle += orbitSpeed * Time.deltaTime;
        Quaternion orbitRotation = Quaternion.Euler(0f, currentAngle, 0f);

        // Apply rotation to offset
        Vector3 rotatedOffset = orbitRotation * offset;

        // Add subtle vertical bobbing
        float bob = Mathf.Sin(Time.time * bobSpeed) * bobAmount;
        rotatedOffset.y += bob;

        Vector3 desiredPosition = target.position + rotatedOffset;

        // Smooth follow
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // Always look at target
        transform.LookAt(target);
    }
}